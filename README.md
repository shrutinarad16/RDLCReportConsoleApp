# 📊 RDLC Report Console Application – Student Performance Reporter

## 🔍 Overview
This is a **.NET-based console application** that dynamically fetches the **Top 5 performing students** from a SQL Server database using a stored procedure and then generates a **professional PDF report** using **RDLC (Report Definition Language Client-side)**.

> 🎯 A lightweight, plug-and-play solution for academic institutions, training departments, or enterprise reporting systems needing high-quality offline performance summaries.

---

## 🧠 Key Features

- ✅ **Real-time Data Fetching**: Pulls top 5 students using stored procedure `GetTop5Students`
- 📄 **Professional PDF Reporting**: RDLC-generated PDFs styled for readability
- 🖥️ **Console-based Execution**: Simple, no-GUI CLI app for automation or integration
- 🛠️ **Customizable**: Swap stored procedure, schema, or report design as needed
- 🔒 **Offline-First**: Report generation works fully offline after DB connection
- 🔁 **Reusable Engine**: Core logic can be reused in web apps or APIs

---

## 👨‍💻 Technologies Used

| Technology       | Purpose                                      |
|------------------|----------------------------------------------|
| C# (.NET)        | Console app logic and report generation      |
| RDLC             | Local report design & rendering to PDF       |
| ADO.NET          | Database access using `SqlDataAdapter`       |
| SQL Server       | Backend data storage                         |
| Stored Procedure | Business logic encapsulated in `GetTop5Students` |
| PDF Renderer     | Built-in to `Microsoft.Reporting.WinForms`   |

---

## ⚙️ How It Works

A[Main Method Starts] --> B[Connect to SQL Server]
B --> C[Call Stored Procedure: GetTop5Students]
C --> D[Fill DataTable with Top 5 Student Records]
D --> E{Is DataTable Empty?}
E -->|Yes| F[Display 'No data found']
E -->|No| G[Load RDLC Template]
G --> H[Bind DataTable to ReportDataSource]
H --> I[Render Report to PDF Bytes]
I --> J[Save PDF File to Disk as StudentDetails.pdf]

## sample output
+---------------------+------------+
| Student Name        | Score (%)  |
+---------------------+------------+
| Alice Johnson       | 98.2       |
| Rahul Sharma        | 96.7       |
| Emily Rodriguez     | 95.9       |
| Aman Verma          | 95.0       |
| Shruti Narad        | 94.6       |
+---------------------+------------+


# 🧩 Real-world Use Cases
🎓 Universities & Colleges – Academic merit list generation

🏢 Corporate L&D Teams – Performance of top internal learners

📊 Analytics Departments – Light reporting without heavy BI tools

📎 Offline Reporting Modules – Useful for field-level audits or education boards

#  How to Run the Application
## 1. ✅ Prerequisites
Visual Studio installed with:

.NET Framework (4.x) or .NET Core/5+ with WinForms RDLC support

Microsoft.ReportViewer.WinForms NuGet package

SQL Server with:

A Students table

A stored procedure named GetTop5Students

## 2. ⚙️ Setup Database
-- Sample table
```sql
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Score FLOAT
);
```
-- Sample stored procedure
```sql
CREATE PROCEDURE GetTop5Students
AS
BEGIN
    SELECT TOP 5 Name, Score
    FROM Students
    ORDER BY Score DESC;
END
```
## 3. 📝 Update App.config
```<configuration>
  <connectionStrings>
    <add name="StudentDBConnection" connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DB_NAME;Integrated Security=True" />
  </connectionStrings>
</configuration>```
      
## 4. 📄 Add RDLC File
Place StudentReport.rdlc in your project root directory.
Ensure:

The DataSet Name inside the RDLC is: StudentDataSet

Fields Name and Score exist in both RDLC and your SQL result

## 5. ▶️ Run the Application
Build and run from Visual Studio or CLI:

```dotnet run```
🎉 Output PDF StudentDetails.pdf will be created in your build directory.

# 💼 Business Value Proposition
This tool is designed with business clarity in mind:

Feature	Value for Business Leaders
🧠 Data → Decisions	Converts raw data into actionable reports
⏳ Time-saving	Automates weekly/monthly reporting
📋 HR/CEO Ready PDFs	Shareable without extra formatting
🧩 Modular & Extendable	Fits into larger enterprise systems
💻 Tech-agnostic Outputs	Works offline and needs no BI licenses


# 🌱 Future Enhancements
⏲️ Windows Service for scheduled reports

📧 Email auto-dispatch after report generation

📊 RDLC Chart Support for visual analytics

🔐 User authentication layer

🌐 Web version using ASP.NET MVC/Core

# 🧑‍💻 About the Developer
## Shruti Narad
🖥️ Software Engineer
📧 Email: shrutinarad123@gmail.com
🌐 LinkedIn: www.linkedin.com/in/shrutinarad16

“I build software that transforms data into decisions.”

