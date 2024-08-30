# Requirements
:white_check_mark: IDE (Visual Studio)
:white_check_mark: Install SQL Server
:white_check_mark: Microsoft SQL Server Management Studio

# Steup in VS IDE 
- Ceate a new project
- Choose 'Console App' (which includes Windows, Linux, MacOS supports)
- use `NuGet` package (like `npm`) => right click on your project layer => `Manage NuGet Packages...` => install `System.Data.SqlClient`

# For Dapper CRUD
- Create a class as a data transfer object (BlogDto.cs)
- Create a class as a db connection string (ConnectionStrings.cs)
- Create a class for dapper process handling all CRUD.

# For EF Core CRUD
There are two types of entity frameworks. (Esp for Dot Net framework and Dot Net Core)
- Install Microsoft.EntityFrameworkCore
- Install Microsoft.EntityFrameworkCore.SqlServer
- Create AppDbContext.cs
- Make some changes in BlogDto such as describing Table and Key.
- 

