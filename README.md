
# TextilesGeomar.API

## Setup Instructions

### 1. Prerequisites

- Download and install:
  - Docker
  - Visual Studio 2022 Community Edition

### 2. Run Database in Docker

Execute the following commands in your terminal (for Linux containers):

```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=DBPassword' \
-p 1433:1433 --name textilesgeomar-db -d mcr.microsoft.com/mssql/server:2022-latest
```

### 3. Create Database Tables and Relationships

(Provide details on how to create the necessary tables and their relationships here.)

### 4. Create ASP.NET Core Web API Project

(Provide steps for creating the project, if necessary.)

### 5. Install Required Packages

Install the following NuGet packages in your project:

- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`

### 6. Setup Models

1. Create a **Models** folder in your project.
2. Open the **Package Manager Console** (found under Tools > NuGet Package Manager).
3. Run the following command to update the project and create models based on the existing database tables (make sure to replace `DBPassword` with the correct password):

   ```powershell
   Scaffold-DbContext "Server=localhost; Database=textilesGeomar; User Id=sa; Password=DBPassword; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
   ```

### 7. Rename the DbContext

- Rename `TextilesGeomarContext` to `TextilesGeomarDBContext`.

### 8. Organize Data Folder

- Create a **Data** folder and move `TextilesGeomarDBContext` into it.

### 9. Add Migrations

To add the first migration and update the database (second command is used if migrations folder structure changes):

```powershell
Add-Migration FirstMigration
Or
dotnet ef migrations add InitialCreate --output-dir Data/Migrations
Update-Database
```

### 10. Managing Future Changes

- For any changes made to the models, always create a new migration.

### 11. Applying Previous Migrations

To revert to a previous migration, use the following command:

```powershell
Update-Database PreviousMigrationName
```

### 12. Important Notes on Migrations

- Migrations are intended to be used from the model to the database only. 
- If significant changes are made directly in the database, it’s advisable to regenerate the models using the command:

   ```powershell
   Scaffold-DbContext "Server=localhost; Database=textilesGeomar; User Id=sa; Password=DBPassword; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
   ```

- After regenerating the models, add a migration for the changes:

   ```powershell
   Add-Migration ChangedDBMigration 
   Update-Database
   ```
