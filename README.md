# CargoFlow API

## Project Overview

**CargoFlow** is a layered ASP.NET Core Web API project developed to demonstrate modern backend development practices through a logistics and shipment management scenario. It showcases clean architecture principles with a separation of concerns across four layers: Entities, Data Access, Business Logic, and API Presentation.

The project emphasizes foundational .NET development skills including Entity Framework Core, RESTful API design, dependency injection, and repository patterns.

---

## Technologies

- **Framework:** ASP.NET Core 7.0
- **Language:** C# 11 with nullable reference types enabled
- **Database:** SQLite (development)
- **ORM:** Entity Framework Core 7.0
- **API Documentation:** Swagger/OpenAPI
- **Architecture:** Clean Architecture with Repository and Service Patterns
- **Logging:** Built-in .NET Core logging

---

## Architecture

CargoFlow follows a **layered architecture** design:

```
CargoFlow.API (Presentation Layer)
    ├── Controllers (REST endpoints)
    ├── Middleware (exception handling)
    └── Program.cs (DI & configuration)

CargoFlow.Business (Business Logic Layer)
    ├── Abstract (service interfaces)
    ├── Concrete (service implementations)
    └── DTOs (data transfer objects)

CargoFlow.DataAccess (Data Access Layer)
    ├── Interfaces (repository contracts)
    ├── Repositories (EF Core implementations)
    ├── CargoFlowDbContext.cs (database context)
    └── Migrations (EF Core migrations)

CargoFlow.Entities (Domain Layer)
    ├── BaseEntity.cs
    ├── Customer.cs
    ├── Shipment.cs
    ├── Driver.cs
    ├── Vehicle.cs
    └── ShipmentStatus.cs (enum)
```

### Key Patterns Used

- **Repository Pattern:** Abstracts data access logic
- **Service Pattern:** Encapsulates business logic and validation
- **Dependency Injection:** Loose coupling via ASP.NET Core DI container
- **DTO Pattern:** Separates domain entities from API contracts
- **Middleware Pattern:** Centralized exception handling

---

## Folder Structure

```
CargoFlowAPI/
├── CargoFlow.API/
│   ├── Controllers/
│   │   ├── CustomersController.cs
│   │   ├── ShipmentsController.cs
│   │   └── DashboardController.cs
│   ├── Middleware/
│   │   └── ExceptionMiddleware.cs
│   ├── Program.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── CargoFlow.API.csproj
│
├── CargoFlow.Business/
│   ├── Abstract/
│   │   ├── ICustomerService.cs
│   │   ├── IShipmentService.cs
│   │   └── IDashboardService.cs
│   ├── Concrete/
│   │   ├── CustomerService.cs
│   │   ├── ShipmentService.cs
│   │   └── DashboardService.cs
│   ├── DTOs/
│   │   ├── Customers/
│   │   │   ├── CustomerDto.cs
│   │   │   ├── CreateCustomerDto.cs
│   │   │   └── UpdateCustomerDto.cs
│   │   ├── Shipments/
│   │   │   ├── ShipmentDto.cs
│   │   │   ├── CreateShipmentDto.cs
│   │   │   └── UpdateShipmentDto.cs
│   │   └── Dashboard/
│   │       └── DashboardDto.cs
│   └── CargoFlow.Business.csproj
│
├── CargoFlow.DataAccess/
│   ├── Interfaces/
│   │   ├── IRepository.cs
│   │   ├── ICustomerRepository.cs
│   │   └── IShipmentRepository.cs
│   ├── Repositories/
│   │   ├── Repository.cs (generic)
│   │   ├── CustomerRepository.cs
│   │   └── ShipmentRepository.cs
│   ├── Migrations/
│   │   ├── [timestamp]_InitialCreate.cs
│   │   └── CargoFlowDbContextModelSnapshot.cs
│   ├── CargoFlowDbContext.cs
│   ├── SeedDataExtensions.cs
│   └── CargoFlow.DataAccess.csproj
│
├── CargoFlow.Entities/
│   ├── BaseEntity.cs
│   ├── Customer.cs
│   ├── Shipment.cs
│   ├── Driver.cs
│   ├── Vehicle.cs
│   ├── ShipmentStatus.cs
│   └── CargoFlow.Entities.csproj
│
├── CargoFlow.sln
└── README.md
```

---

## Features

### Core Functionality

✅ **Customer Management**
- Create, read, update, delete customers
- Track customer details (name, email, phone)
- Automatic timestamp tracking

✅ **Shipment Tracking**
- Full CRUD operations for shipments
- Status tracking (Created, InWarehouse, InTransit, Delivered, Cancelled)
- Origin and destination management
- Weight tracking
- Automatic timestamp logging

✅ **Dashboard Analytics**
- Shipment statistics and metrics
- Shipment count by status
- Total customer count

✅ **Global Exception Handling**
- Centralized error handling middleware
- Consistent JSON error responses

✅ **Development Seed Data**
- Automatic database initialization with 5 customers
- 10 realistic shipment records
- Idempotent seeding (runs only on empty database)

✅ **Input Validation**
- Customer: required email, first/last names
- Shipment: required tracking number, origin, destination, weight > 0

---

## API Endpoints

### Customers

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/customers` | Get all customers |
| `GET` | `/api/customers/{id}` | Get customer by ID |
| `POST` | `/api/customers` | Create new customer |
| `PUT` | `/api/customers/{id}` | Update customer |
| `DELETE` | `/api/customers/{id}` | Delete customer |

### Shipments

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/shipments` | Get all shipments |
| `GET` | `/api/shipments/{id}` | Get shipment by ID |
| `POST` | `/api/shipments` | Create new shipment |
| `PUT` | `/api/shipments/{id}` | Update shipment |
| `DELETE` | `/api/shipments/{id}` | Delete shipment |

### Dashboard

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/dashboard` | Get dashboard metrics |

---

## Dashboard Endpoint

### GET /api/dashboard

Returns shipment and customer statistics.

**Response:**
```json
{
  "totalShipments": 10,
  "deliveredShipments": 3,
  "inTransitShipments": 3,
  "cancelledShipments": 1,
  "totalCustomers": 5
}
```

---

## Installation

### Prerequisites

- .NET 7.0 SDK or later
- SQLite (included with .NET)
- Visual Studio Code or Visual Studio (recommended)

### Clone Repository

```bash
git clone <repository-url>
cd CargoFlowAPI
```

### Restore Dependencies

```bash
dotnet restore
```

### Build Solution

```bash
dotnet build CargoFlow.sln
```

---

## Entity Framework Core

### Create a New Migration

```bash
dotnet ef migrations add <MigrationName> -s CargoFlow.API -p CargoFlow.DataAccess -o Migrations
```

**Example:**
```bash
dotnet ef migrations add AddShipmentStatus -s CargoFlow.API -p CargoFlow.DataAccess
```

### Apply Migrations

```bash
dotnet ef database update -s CargoFlow.API -p CargoFlow.DataAccess
```

### Drop Database (Development Only)

```bash
dotnet ef database drop -s CargoFlow.API -p CargoFlow.DataAccess
```

### View Migration Status

```bash
dotnet ef migrations list -s CargoFlow.API -p CargoFlow.DataAccess
```

---

## Running the Application

### Development Mode

```bash
dotnet run --project CargoFlow.API
```

The API will start at:
- **HTTP:** `http://localhost:5000`
- **HTTPS:** `https://localhost:5001`

### Production Mode

```bash
dotnet build -c Release
dotnet run --project CargoFlow.API -c Release
```

---

## Swagger Documentation

Once the application is running, access the interactive API documentation:

**Default Development Port:**
```
http://localhost:5041/swagger
```

Note: The port may vary depending on your `launchSettings.json` configuration. Check the console output when running `dotnet run --project CargoFlow.API` to confirm the exact URL.

**Features:**
- Try out endpoints directly
- View request/response schemas
- See sample payloads
- Explore all available endpoints

---

## Screenshots

### Swagger Overview
![Swagger Overview](docs/screenshots/swagger-overview.png)

### Dashboard Response
![Dashboard Response](docs/screenshots/dashboard-response.png)

---

## Sample Requests

### Create a Customer

**Request:**
```bash
curl -X POST https://localhost:5001/api/customers \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Jane",
    "lastName": "Doe",
    "email": "jane.doe@example.com",
    "phoneNumber": "+1-555-0106"
  }'
```

**Response:**
```json
{
  "id": 6,
  "firstName": "Jane",
  "lastName": "Doe",
  "email": "jane.doe@example.com",
  "phoneNumber": "+1-555-0106",
  "createdDate": "2026-06-10T12:34:56Z"
}
```

### Create a Shipment

**Request:**
```bash
curl -X POST https://localhost:5001/api/shipments \
  -H "Content-Type: application/json" \
  -d '{
    "trackingNumber": "SHP-2026-011",
    "origin": "Portland, OR",
    "destination": "Sacramento, CA",
    "weight": 145.5
  }'
```

**Response:**
```json
{
  "id": 11,
  "trackingNumber": "SHP-2026-011",
  "origin": "Portland, OR",
  "destination": "Sacramento, CA",
  "weight": 145.5,
  "status": "Created",
  "createdDate": "2026-06-10T12:35:22Z"
}
```

### Get Dashboard Metrics

**Request:**
```bash
curl https://localhost:5001/api/dashboard
```

**Response:**
```json
{
  "totalShipments": 11,
  "deliveredShipments": 3,
  "inTransitShipments": 3,
  "cancelledShipments": 1,
  "totalCustomers": 6
}
```

### Update a Customer

**Request:**
```bash
curl -X PUT https://localhost:5001/api/customers/6 \
  -H "Content-Type: application/json" \
  -d '{
    "firstName": "Jane",
    "lastName": "Smith",
    "email": "jane.smith@example.com",
    "phoneNumber": "+1-555-0107"
  }'
```

### Delete a Shipment

**Request:**
```bash
curl -X DELETE https://localhost:5001/api/shipments/11
```

---

## Error Handling

### Exception Response Format

All errors return a consistent JSON response:

```json
{
  "success": false,
  "message": "An unexpected error occurred."
}
```

**HTTP Status Codes:**
- `200 OK` - Request succeeded
- `201 Created` - Resource created successfully
- `204 No Content` - Resource deleted successfully
- `400 Bad Request` - Invalid input
- `404 Not Found` - Resource not found
- `500 Internal Server Error` - Unhandled exception

---

## Development Database

The application uses SQLite for development. The database file (`cargoflow.db`) is created automatically on first run.

### Reset Database

```bash
# Delete the database file
rm cargoflow.db

# Rebuild and run
dotnet build
dotnet run --project CargoFlow.API
```

The database will be recreated and seeded with sample data automatically.

---

## Future Improvements

### Short Term

- [ ] Add unit tests and integration tests
- [ ] Implement authentication (JWT)
- [ ] Add role-based authorization
- [ ] Add data validation attributes
- [ ] Implement pagination for list endpoints
- [ ] Add filtering and sorting capabilities
- [ ] Implement soft delete functionality

### Medium Term

- [ ] Add Driver and Vehicle CRUD endpoints
- [ ] Implement shipment status history tracking
- [ ] Add email notifications for status changes
- [ ] Implement file upload (invoices, documents)
- [ ] Add API versioning
- [ ] Create comprehensive unit and integration test suite

### Long Term

- [ ] Add real-time tracking with WebSockets
- [ ] Implement advanced analytics dashboard
- [ ] Add integration with third-party carriers
- [ ] Support multiple database providers (SQL Server, PostgreSQL)
- [ ] Implement caching layer (Redis)
- [ ] Add Docker containerization
- [ ] Deploy to cloud (Azure, AWS)
- [ ] Implement microservices architecture if needed at scale

---

## Job Requirement Alignment

This project was designed to align with Junior / Junior+ .NET Developer role requirements. It covers:

- **C#** - Modern language features, nullable reference types, async/await patterns
- **ASP.NET Core Web API** - RESTful API design, controllers, middleware, routing
- **Entity Framework Core** - DbContext, migrations, entity relationships, LINQ queries
- **SQL Database Integration** - Schema design, migrations, data persistence
- **Repository Pattern** - Generic and specific repository implementations
- **Service Layer** - Business logic encapsulation and validation
- **DTO Usage** - Data Transfer Objects for API contracts
- **Dependency Injection** - Container configuration and service registration
- **RESTful API Development** - HTTP methods, status codes, request/response handling
- **Swagger/OpenAPI** - API documentation and interactive testing
- **Git Version Control** - Source control and version management
- **Clean Architecture Principles** - Layered design, separation of concerns, SOLID principles

---

## About This Project

**CargoFlow** is a portfolio project developed to practice and demonstrate core .NET development skills in a realistic business domain. It serves as a reference implementation of clean architecture principles and common enterprise patterns applied at an appropriate scale for a junior developer.

---

## License

This project is provided as-is for educational and development purposes.

---

## Support

For issues, questions, or contributions, please reach out or open an issue in the repository.

---

**Last Updated:** June 10, 2026
**Version:** 1.0.0