# Task Management API - Project Structure

This project follows **Clean Architecture** principles with clear separation of concerns across four layers:

## Project Structure

```
src/
├── TaskManagement.Domain/          # Core domain layer (innermost)
│   ├── Entities/                   # Domain entities
│   └── Interfaces/                 # Domain interfaces
│
├── TaskManagement.Application/     # Application business logic
│   ├── DTOs/                       # Data Transfer Objects
│   ├── Interfaces/                 # Application interfaces
│   └── Services/                   # Application services
│
├── TaskManagement.Infrastructure/  # External concerns
│   ├── Data/                       # Database context and configurations
│   └── Repositories/               # Repository implementations
│
└── TaskManagement.API/             # Presentation layer (outermost)
    ├── Controllers/                # API Controllers
    ├── Program.cs                  # Application entry point
    └── appsettings.json            # Configuration settings
```

## Architecture Layers

### 1. Domain Layer (Core)
- Contains business entities and domain logic
- No dependencies on other layers
- Framework-independent

### 2. Application Layer
- Contains application business logic
- Depends only on Domain layer
- Defines interfaces for infrastructure

### 3. Infrastructure Layer
- Implements data access and external services
- Depends on Application and Domain layers
- Contains EF Core DbContext and repositories

### 4. API Layer (Presentation)
- ASP.NET Core Web API
- Depends on Application and Infrastructure layers
- Contains controllers and middleware configuration

## Dependencies Flow

```
API → Infrastructure → Application → Domain
```

The dependency rule: Inner layers should not depend on outer layers.
