# Task Management API

A CRUD-based API for task management built with **ASP.NET Core 6** and **Clean Architecture**.

## Project Structure

This project follows Clean Architecture principles with the following layers:

- **Domain** - Core business entities and interfaces
- **Application** - Business logic and use cases
- **Infrastructure** - Data access and external services
- **API** - Web API controllers and configuration

## Prerequisites

- .NET 6.0 SDK or later
- SQL Server (for production use)

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/shreshth-borkar-insightsoftware/task-api-management.git
cd task-api-management
```

### 2. Restore dependencies

```bash
dotnet restore
```

### 3. Update connection string

Update the SQL Server connection string in `src/TaskManagement.API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TaskManagementDb;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True"
  }
}
```

### 4. Build the solution

```bash
dotnet build
```

### 5. Run the API

```bash
cd src/TaskManagement.API
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:7xxx`
- HTTP: `http://localhost:5xxx`
- Swagger UI: `https://localhost:7xxx/swagger`

## Project Structure

See [src/README.md](src/README.md) for detailed project structure documentation.

## Features

- Clean Architecture implementation
- Swagger/OpenAPI documentation
- Configured for SQL Server database
- Separation of concerns across layers

## Technologies

- ASP.NET Core 6.0
- Swagger/Swashbuckle
- Entity Framework Core (ready for integration)
- Dependency Injection

## License

This project is licensed under the MIT License.
