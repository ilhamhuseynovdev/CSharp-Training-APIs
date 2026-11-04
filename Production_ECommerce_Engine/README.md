# 🚀 Production E-Commerce Engine API

A production-grade RESTful backend service built for scalable e-commerce operations. This project enhances the previous N-Tier architecture by introducing data pagination for large datasets and sets the foundation for external API integrations.

## 🚀 Features

- **Data Pagination:** Optimized database queries using `Skip` and `Take` logic to return product listings in manageable chunks.
- **Clean Architecture (N-Tier):** Complete separation of business logic (Services) from HTTP routing (Controllers).
- **Unified Response Model:** Standardized API responses across all endpoints using a custom generic `ServiceResult<T>` pattern.
- **Centralized Handling:** Dynamic HTTP status code resolution via a custom base controller.
- **External API Integration (⏳ Planned):** Upcoming feature to integrate real-time currency conversion (AZN to USD) for cart totals using `HttpClient`.

## 📊 Database Schema (PostgreSQL)

- **Users:** `Id` (PK), `UserName`, `Email`
- **Products:** `Id` (PK), `Name`, `Price`, `StockQuantity`
- **Carts:** `Id` (PK), `UserId` (FK), `IsActive`
- **CartItems:** `Id` (PK), `CartId` (FK), `ProductId` (FK), `Quantity`

## 🛠️ Endpoints Overview

### Products (`/api/products`)

- `GET /api/products?pageNumber={x}&pageSize={y}` - Retrieves paginated product listings.
- `POST /api/products/create-product` - Creates a new product.
- `POST /api/products/create-user` - Creates a mock user for testing.

### Carts (`/api/carts`)

- `POST /api/carts/addtocart` - Adds items to the user's active cart.
- `GET /api/carts/allcarts/{userId}` - Retrieves the active cart with calculated totals.
- `POST /api/carts/checkout/{userId}` - Processes checkout and deducts inventory.

## ⚙️ How to Run

1. Clone the repository.
2. Update the PostgreSQL connection string in `appsettings.json`.
3. Download packages: FluentValidation.AspNetCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Tools, Npgsql.EntityFrameworkCore.PostgreSQL
4. Open "Package Manager Console" and run "update-database"
5. Run the Code.