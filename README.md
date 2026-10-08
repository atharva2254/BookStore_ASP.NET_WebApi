# BookStore — E-Commerce Book Management API

A RESTful **ASP.NET Core Web API** built to demonstrate **Clean Architecture, separation of concerns, dependency inversion, and scalable backend design**.

## Tech Stack

- **C# / ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**

## Key Features

- Clean Architecture with independent Domain, Application, Infrastructure, and API layers
- JWT-based authentication with secure password hashing
- Book CRUD operations
- User registration and login
- Shopping cart management
- Order creation and checkout
- Purchase-time price preservation
- User-specific order history
- EF Core migrations and SQL Server persistence
- Repository and Service abstractions
- Dependency Injection throughout the application

## Architecture

The project follows **Clean Architecture**, keeping business logic independent from frameworks, databases, and external infrastructure.

```text
                    ┌──────────────┐
                    │     API      │
                    │ Controllers  │
                    └──────┬───────┘
                           │
                           ▼
                    ┌──────────────┐
                    │ Application  │
                    │ Services     │
                    │ DTOs         │
                    │ Interfaces   │
                    └──────┬───────┘
                           │
                           ▼
                    ┌──────────────┐
                    │   Domain     │
                    │   Entities   │
                    │   Business   │
                    │   Rules      │
                    └──────────────┘
                           ▲
                           │
                    ┌──────┴────────┐
                    │ Infrastructure│
                    │ EF Core       │
                    │ Repositories  │
                    │ SQL Server    │
                    └───────────────┘
```

### Dependency Flow

```text
API → Application → Domain

Infrastructure → Application
Infrastructure → Domain
```

The **Domain layer has no dependency on Infrastructure or API**, keeping the core business logic independent of technical implementation details.

## Project Structure

```text
BookStore
│
├── BookStore.Domain
│   └── Entities
│       ├── Book.cs
│       ├── User.cs
│       ├── CartItem.cs
│       ├── Order.cs
│       └── OrderItem.cs
│
├── BookStore.Application
│   ├── DTOs
│   ├── Interfaces
│   │   ├── Repositories
│   │   └── Services
│   └── Services
│
├── BookStore.Infrastructure
│   ├── Configuration
│   │   └── AppDbContext.cs
│   ├── Repositories
│   └── Migrations
│
└── BookStore.API
    ├── Controllers
    ├── Program.cs
    └── appsettings.json
```

## Layer Responsibilities

### Domain

Contains the core business entities and rules.

```text
Book
User
CartItem
Order
OrderItem
```

The Domain layer does not depend on EF Core, SQL Server, or ASP.NET Core.

### Application

Contains application use cases and abstractions.

```text
DTOs
Service Interfaces
Repository Interfaces
Application Services
```

It defines **what the application needs**, without knowing how infrastructure implements it.

### Infrastructure

Contains technical implementations.

```text
EF Core
DbContext
Repository Implementations
SQL Server
Migrations
```

For example:

```text
IBookRepository
       ↑
       │ implements
       │
BookRepository
       ↓
   EF Core
       ↓
  SQL Server
```

### API

Acts as the entry point to the application.

```text
HTTP Request
     ↓
Controller
     ↓
Application Service
     ↓
Repository
     ↓
Database
```

Controllers remain thin and delegate business operations to the Application layer.

## Authentication Flow

```text
Register
   ↓
Password Hashing
   ↓
Store User
```

```text
Login
   ↓
Verify Password
   ↓
Generate JWT
   ↓
Authenticated Request
   ↓
[Authorize] Endpoints
```

User-specific resources are accessed using the authenticated user's ID from JWT claims rather than accepting the user ID directly from the request.

## Order Flow

```text
User
 ↓
Cart
 ↓
Checkout
 ↓
Create Order
 ↓
Create OrderItems
 ↓
Calculate Total
 ↓
Clear Cart
```

`OrderItem` stores the **UnitPrice at the time of purchase**, ensuring historical orders remain accurate even if the book price changes later.

## Database Relationships

```text
User
 ├── CartItems ──── Book
 │
 └── Orders
       └── OrderItems ──── Book
```

Main entities:

```text
Users
Books
CartItems
Orders
OrderItems
```

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server
- Visual Studio / VS Code
- Git

### 1. Clone the repository

```bash
git clone <repository-url>
cd BookStore
```

### 2. Configure SQL Server

Update the connection string in:

```text
BookStore.API/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### 3. Apply migrations

Set `BookStore.Infrastructure` as the default project in Package Manager Console and run:

```powershell
Add-Migration InitialCreate
Update-Database
```

### 4. Run the API

```bash
dotnet run --project BookStore.API
```

Swagger can then be used to test the available endpoints.

## Main API Endpoints

### Authentication

```http
POST /api/users/register
POST /api/users/login
```

### Books

```http
POST   /api/books
GET    /api/books
GET    /api/books/{id}
PUT    /api/books/{id}
DELETE /api/books/{id}
```

### Orders

```http
POST /api/orders
GET  /api/orders
GET  /api/orders/{id}
```

Protected endpoints require:

```http
Authorization: Bearer <JWT>
```

## Design Principles Demonstrated

- **Clean Architecture**
- **Separation of Concerns**
- **Dependency Inversion**
- **Dependency Injection**
- **Repository Pattern**
- **Service Layer Pattern**
- **DTO Pattern**
- **Abstraction**
- **Async/Await**
- **Secure Authentication**
- **Relational Database Design**

## Future Improvements

- Payment gateway integration
- Global exception handling middleware
- FluentValidation
- Unit and integration tests
- Transaction / Unit of Work implementation
- Refresh token authentication
- Role-based authorization
- Pagination and filtering
- Docker support

## Purpose

This project was developed as a practical implementation of **Clean Architecture and scalable ASP.NET Core backend development**, with emphasis on maintainability, testability, separation of concerns, and dependency inversion.
