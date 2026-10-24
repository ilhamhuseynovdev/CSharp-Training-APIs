# 🏦 Bank Queue API

A RESTful backend service simulating a real-world bank queue management system. This project demonstrates state management, business logic execution, and relational database handling using ASP.NET Core and Entity Framework Core.

## 🚀 Features

- **Service Management:** Create and list different branch services (e.g., Cashier, Credit) with unique ticket prefixes (e.g., C-101, K-105).
- **Ticket Generation:** Automatically generates sequential ticket numbers based on the selected service type.
- **Queue State Management:** Handles complex business logic to track ticket statuses (`Waiting`, `Serving`, `Completed`).
- **Next-in-Line Calling:** Automatically fetches and updates the oldest waiting ticket for a specific service type.
- **Edge-Case Handling:** Prevents modifications to already completed tickets.

## 📊 Database Schema (PostgreSQL)

- **ServiceTypes:** `Id` (PK), `Name`, `Prefix`
- **Tickets:** `Id` (PK), `TicketNumber` (int), `IssueTime`, `Status` (Enum), `ServiceTypeId` (FK)

## 🛠️ Endpoints Overview

### Service Types (`/api/servicetypes`)

- `GET /api/servicetypes` - Retrieves all available services.
- `POST /api/servicetypes` - Creates a new service type (Requires Name and Prefix).

### Tickets (`/api/tickets`)

- `POST /api/tickets/take/{serviceId}` - Generates a new ticket for the specified service and sets status to `Waiting`.
- `PUT /api/tickets/call-next/{serviceTypeId}` - Calls the oldest waiting ticket in the given service queue and updates its status to `Serving`.
- `PUT /api/tickets/complete/{ticketId}` - Marks a specific ticket's status as `Completed`.

## ⚙️ How to Run

1. Clone the repository.
2. Update the PostgreSQL connection string in `appsettings.json`.
3. Download packages: FluentValidation.AspNetCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Tools, Npgsql.EntityFrameworkCore.PostgreSQL.
4. Open "Package Manager Console" and run "update-database".
5. Run the Code.
