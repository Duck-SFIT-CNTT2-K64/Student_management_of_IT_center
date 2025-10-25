# Project: Informatics Center Student Management

This is a C# WinForms project (using .NET Framework) for an "Informatics Center Student Management" application. The application allows for the management of student information, courses, classes, grades, and other related operations.

## 1. Technology Stack

* **Language:** C#
* **Platform:** .NET WinForms (Windows Forms)
* **Framework:** [.NET Framework 4.7.2 - *or your .NET version*]
* **Database:** SQL Server
* **Source Control:** Git & GitHub

## 2. Prerequisites

To run this project, your machine must have the following software installed:

1.  **Visual Studio 2019** (or 2022).
    * During installation, ensure the **".NET desktop development"** workload is selected.
2.  **SQL Server 2019** (or any Express / Developer edition).
3.  **SQL Server Management Studio (SSMS)** (Recommended).

## 3. Installation & Setup Guide

Please follow these steps precisely to set up the environment and run the project.

### Step 1: Clone the Project from Git

Use `git clone` to download the project to your machine:
```bash
git clone https://github.com/Duck-SFIT-CNTT2-K64/Student_management_of_IT_center.git
```

### Step 2: Open the Project
Navigate to the Student_manager folder (or your solution's folder name) and double-click the Student_manager.sln file to open it with Visual Studio.

### Step 3: Restore NuGet Packages
Visual Studio will usually restore NuGet packages (like AntdUI, Entity Framework, etc.) automatically when you open the project. If not:

1. **Go to Tools -> NuGet Package Manager -> Package Manager Console.

2. **Type the following command and press Enter:
```bash
Update-Package -Reinstall
```
Alternatively, right-click the Solution in Solution Explorer and select Restore NuGet Packages.

### Step 4: Configure the Database (Most Important)
This project uses either a SQL script or a database backup file (.bak) to create the database.

[CHOOSE ONE OF THE TWO METHODS BELOW - YOU MUST PROVIDE THE SCRIPT OR .BAK FILE FOR YOUR TEAM]

#### Method 1: Run SQL Script (Recommended)

1. **Open SSMS (SQL Server Management Studio) and connect to your SQL Server instance.

2. **Right-click on Databases -> New Database.

3. **Set a name for your database, e.g., IC_StudentManagement.

4. **Open the database script file (e.g., Database/script.sql - you need to provide this file) using SSMS.

5. **Ensure you have selected the IC_StudentManagement database in the toolbar, then press Execute to run the script, which will create tables and insert data.

#### Method 2: Restore from .bak file

1. **Open SSMS and connect to your SQL Server instance.

2. **Right-click on Databases -> Restore Database....

3. **Select Device and navigate to the .bak file you provided (e.g., Database/QLSV.bak).

4. **In the Database destination field, type the desired database name (e.g., IC_StudentManagement) and click OK.

### Step 5: Update the Connection String
After creating the database, you must update the connection string in the project to point to your database.

1. **In Visual Studio, open the App.config file (or Settings.settings).

2. **Find the <connectionStrings> tag.

3. **You will see a connection string; modify it accordingly:
```bash
<connectionStrings>
  <add name="MyConnectionString" 
       connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DB_NAME;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```
    Data Source: Replace with your SQL Server name (e.g., .\SQLEXPRESS, DESKTOP-ABC\SQL2019, or just . for the default instance).

    Initial Catalog: Replace with the database name you created in Step 4 (e.g., IC_StudentManagement).

    Integrated Security=True: Use this if you use Windows Authentication. If you use a SQL account (user/pass), the string should be: User ID=sa;Password=yourpassword;

### Step 6: Build and Run the Project
1. **In Visual Studio, go to the Build menu -> Rebuild Solution** to ensure there are no errors.

2. **Press F5 or click the "Start" button** (green play icon) to run the project.

## 4. Authors (Maybe update in the future...)
[Bui Hai Duc] - [Role: Team Lead, Tester, Database]

[Dinh Quang Hung] - [Role: UI/UX, Feature]

[Dang Hoang Huy] - [Role: UI/UX, Feature]

[Nguyen Manh Tien] - [Role: UI/UX, Feature]