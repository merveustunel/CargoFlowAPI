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

## Web Frontend

A clean, Bootstrap-based frontend is included in the `CargoFlow.Web` folder. Built with vanilla HTML, CSS, and JavaScript.

**Features:**
- Dashboard with real-time metrics
- Customer management interface
- Shipment management with status tracking
- Public shipment tracking page
- Responsive Bootstrap 5 design
- No external frameworks (React, Vue, etc.)

**Getting Started:**
```bash
cd CargoFlow.Web
# Open index.html in a browser, or use a local server:
python -m http.server 8000
```

API URL: `http://localhost:5041/api`

For detailed frontend documentation, see [CargoFlow.Web/README.md](CargoFlow.Web/README.md).

---

## Screenshots

### 1. Dashboard
<img width="1596" height="712" alt="image" src="https://github.com/user-attachments/assets/9712d6c8-cda0-4fa7-b8a3-fc782674c2b3" />


The **Dashboard** is the main entry point providing a quick overview of key business metrics:
- **Total Shipments:** Displays the total count of all shipments in the system
- **Delivered Shipments:** Shows shipments successfully delivered to their destinations
- **In Transit Shipments:** Shows shipments currently on the way
- **Cancelled Shipments:** Shows cancelled shipments
- **Customer Summary:** Total registered customers with quick navigation to view all customers
- **Quick Actions:** Navigation buttons for:
  - Adding new customers
  - Creating new shipments
  - Accessing the public tracking page

The dashboard uses color-coded metric cards (dark blue, green, light blue, red) for visual clarity and quick scanning of system status.

---

### 2. Customers Management
<img width="1421" height="710" alt="image" src="https://github.com/user-attachments/assets/871d1812-98a4-4480-8227-afa488a6b487" />


The **Customers** page provides full customer lifecycle management:
- **Customer List Table:** Displays all customers with columns for:
  - ID
  - Full Name (First + Last Name)
  - Email address
  - Phone number (with +90-532- Turkish format for demo data)
  - Account creation date
- **Actions Column:** Each customer row has:
  - **Edit button** (yellow) - Opens modal form to update customer details
  - **Delete button** (red) - Removes customer from system with confirmation
- **Add New Customer Button:** Creates a new customer with form validation for:
  - First name (required)
  - Last name (required)
  - Email address (required)
  - Phone number (required)

The demo database seeds with 8 realistic customers for portfolio demonstration.

---

### 3. Shipments Management

<img width="1917" height="964" alt="image" src="https://github.com/user-attachments/assets/b3867843-f4ec-428a-a043-c18a72e17f36" />

The **Shipments** page enables comprehensive shipment tracking and management:
- **Shipment List Table:** Displays all shipments with columns for:
  - ID
  - Tracking Number (format: CF-2026-001, CF-2026-002, etc.)
  - Origin city (Turkish cities like İstanbul, Ankara, İzmir)
  - Destination city
  - Weight in kilograms
  - Current Status with color-coded badge:
    - Created (gray)
    - InWarehouse (orange)
    - InTransit (light blue)
    - Delivered (green)
    - Cancelled (red)
  - Creation date and time
- **Actions Column:** Each shipment has:
  - **Update Status button** (cyan) - Opens dedicated modal to change shipment status
  - **Edit button** (yellow) - Updates shipment details (origin, destination, weight)
  - **Delete button** (red) - Removes shipment with confirmation
- **Create Shipment Button:** Opens form to create new shipments with:
  - Tracking number (auto-generated suggestion: CF-2026-###)
  - Origin and destination cities
  - Weight in kilograms

The demo seeds with 20 realistic shipments across Turkish city pairs with varied statuses and weights.

---

### 4. Public Shipment Tracking

<img width="1427" height="706" alt="image" src="https://github.com/user-attachments/assets/9dc53403-59d2-430c-9b25-1bfa7d5eaff2" />


The **Track Your Shipment** page is a public-facing feature for customers to track their shipments:
- **Search Form:** 
  - Input field to enter tracking number (e.g., CF-2026-001)
  - "Track Shipment" button to retrieve shipment details
- **Shipment Details Display:**
  - Tracking Number (prominent display)
  - Current Status (color-coded badge)
  - Origin city
  - Destination city
  - Package weight in kilograms
  - Creation/Order date with timestamp
- **Status Timeline Visualization:** Visual representation of shipment journey through all possible statuses
- **"Track Another Shipment"** button to reset the form and search again

This page demonstrates the public API endpoint `/api/shipments/tracking/{trackingNumber}` which requires no authentication.

---

### 5. Status Timeline
<img width="1919" height="762" alt="image" src="https://github.com/user-attachments/assets/73a68b39-7d00-4192-bacb-a6a7870e74b8" />


The **Status Timeline** section shows the shipment's journey progression:
- **Visual Timeline:** Vertical timeline showing all possible shipment statuses:
  - Order Created
  - In Warehouse
  - In Transit
  - Delivered
  - Cancelled
- **Status Indicators:** Each status is represented with a circular node
- **Current Status Highlighting:** The timeline shows which statuses have been completed and which is current
- **"Track Another Shipment"** button for easy reset

This visual representation helps customers understand:
- Where their shipment currently is in the fulfillment process
- What stages the shipment has already completed
- What future stages remain before delivery

---

## Web Frontend Features

The **CargoFlow.Web** frontend demonstrates modern web development practices:

✅ **Responsive Bootstrap 5 Design** - Works on mobile, tablet, and desktop
✅ **Vanilla JavaScript (ES6+)** - No framework dependencies, lightweight and fast
✅ **Fetch API** - Modern async HTTP requests with async/await
✅ **Modal Forms** - Clean, reusable modal dialogs for data entry
✅ **Form Validation** - Client-side validation before API calls
✅ **Error Handling** - User-friendly error messages and alerts
✅ **Loading States** - Visual feedback while fetching from API
✅ **Status Badges** - Color-coded visual indicators for shipment statuses
✅ **CORS Support** - Frontend-backend communication across localhost ports
✅ **Public API Endpoints** - No authentication required for shipment tracking

---

### 6. Swagger API Documentation
<img width="1917" height="951" alt="image" src="https://github.com/user-attachments/assets/f50b29d4-7593-49d4-bfae-fc229dacf2ee" />

The **Swagger/OpenAPI** interface provides interactive API documentation available at `http://localhost:5041/swagger`

**Features Displayed:**
- **API Title:** "CargoFlow.API v1.0" with OAS3 badge indicating OpenAPI 3.0 specification
- **Endpoints organized by resource:**
  - **Customers** section with 5 endpoints:
    - `GET /api/Customers` - Retrieve all customers
    - `POST /api/Customers` - Create new customer
    - `GET /api/Customers/{id}` - Get specific customer
    - `PUT /api/Customers/{id}` - Update customer (orange badge)
    - `DELETE /api/Customers/{id}` - Delete customer (red badge)
  - **Dashboard** section with 1 endpoint:
    - `GET /api/Dashboard` - Retrieve dashboard metrics
  - **Shipments** section with full CRUD operations

**Color-Coded HTTP Methods:**
- Blue badge: `GET` requests (read operations)
- Green badge: `POST` requests (create operations)
- Orange badge: `PUT` requests (update operations)
- Red badge: `DELETE` requests (delete operations)

**Interactive Features:**
- Click any endpoint to expand and see request/response schemas
- Try out endpoints directly from the browser
- View sample payloads and responses
- Test API without external tools like Postman
- Download OpenAPI specification in JSON or YAML

This Swagger interface serves as both documentation and a testing tool for all API endpoints, making it easy for frontend developers or API consumers to understand and interact with the CargoFlow API.

---

### API Response Examples

<img width="1596" height="712" alt="image" src="https://github.com/user-attachments/assets/f2fb12a8-b2f8-487f-80ee-3349a5a7c72c" />


Sample JSON response showing dashboard metrics with demo data (20 shipments, 8 customers)

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
