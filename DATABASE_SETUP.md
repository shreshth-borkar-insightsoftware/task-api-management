# Database Setup Instructions

This document provides step-by-step instructions for setting up and managing the database for the Task Management API.

## Prerequisites

- SQL Server (LocalDB, Express, or full version)
- .NET 6.0 SDK or later
- EF Core tools (installed globally)

## Database Configuration

### Connection String

The default connection string is configured in `src/TaskManagement.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

For production environments or different database servers, update this connection string accordingly.

### Alternative Connection Strings

**SQL Server with Authentication:**
```json
"DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TaskManagementDb;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True"
```

**SQL Server Express:**
```json
"DefaultConnection": "Server=.\\SQLEXPRESS;Database=TaskManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

## Task Entity Schema

The `TaskItem` entity includes the following properties:

- **Id**: Primary key (int, auto-incremented)
- **Title**: string, required, max 200 characters
- **Description**: string, optional, max 1000 characters
- **DueDate**: DateTime?, nullable
- **Priority**: enum (Low=0, Medium=1, High=2, Critical=3)
- **Status**: enum (Todo=0, InProgress=1, Completed=2)
- **CreatedAt**: DateTime, required
- **UpdatedAt**: DateTime, required

## Database Migration

The initial migration has already been created in `src/TaskManagement.Infrastructure/Data/Migrations/`.

### To Apply Migrations to Database

Run the following command from the solution root directory:

```bash
cd src/TaskManagement.API
dotnet ef database update --project ../TaskManagement.Infrastructure
```

This will create the `TaskManagementDb` database and the `Tasks` table with the schema defined in the migration.

### Creating New Migrations (Future Changes)

If you need to add new migrations after modifying entities:

```bash
cd src/TaskManagement.API
dotnet ef migrations add YourMigrationName --project ../TaskManagement.Infrastructure --output-dir Data/Migrations
```

### Reverting Migrations

To revert to a previous migration:

```bash
cd src/TaskManagement.API
dotnet ef database update PreviousMigrationName --project ../TaskManagement.Infrastructure
```

To remove the last migration (if not yet applied):

```bash
cd src/TaskManagement.API
dotnet ef migrations remove --project ../TaskManagement.Infrastructure
```

## Verification Steps

1. **Build the solution:**
   ```bash
   dotnet build
   ```

2. **Run the API:**
   ```bash
   cd src/TaskManagement.API
   dotnet run
   ```

3. **Access Swagger UI:**
   Navigate to `https://localhost:7xxx/swagger` (replace `xxx` with the actual port shown in console)

4. **Verify database creation:**
   - Connect to your SQL Server instance
   - Confirm that `TaskManagementDb` database exists
   - Verify that the `Tasks` table has been created with the correct schema

## Troubleshooting

### EF Core Tools Not Installed

Install the EF Core tools globally:

```bash
dotnet tool install --global dotnet-ef
```

Or update existing installation:

```bash
dotnet tool update --global dotnet-ef
```

### Database Connection Issues

- Verify SQL Server is running
- Check that the connection string is correct
- Ensure the database user has appropriate permissions
- For LocalDB, verify it's installed and running

### Migration Errors

If you encounter migration errors:

1. Check that all project references are correct
2. Ensure the Infrastructure project has the EF Core packages
3. Verify the DbContext is properly configured in Program.cs
4. Check that the connection string is valid

## Database Context Configuration

The `TaskDbContext` is configured in `Program.cs` with dependency injection:

```csharp
builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

This registers the DbContext with the DI container, making it available for injection into repositories and services.
