using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;


namespace RDLCReportConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataTable studentData = GetTop5Students();

            if (studentData.Rows.Count > 0)
            {
                GenerateRDLCReport(studentData);
                Console.WriteLine("Report generated successfully!");
            }
            else
            {
                Console.WriteLine("No data found.");
            }

            Console.ReadKey();
        }
        static DataTable GetTop5Students()
        {
            DataTable dt = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["StudentDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("GetTop5Students", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }

            return dt;

        }

        static void GenerateRDLCReport(DataTable data)
        {
            LocalReport report = new LocalReport();

            // RDLC file path relative to output directory
            report.ReportPath = "StudentReport.rdlc";

            ReportDataSource rds = new ReportDataSource("StudentDataSet", data);
            report.DataSources.Add(rds);

            byte[] bytes = report.Render("PDF");

            string reportPath = AppDomain.CurrentDomain.BaseDirectory + "StudentDetails.pdf";
            System.IO.File.WriteAllBytes(reportPath, bytes);
        }

    }
}
