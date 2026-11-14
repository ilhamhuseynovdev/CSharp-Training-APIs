# 🖼️ E-Commerce Media Service API

A production-oriented RESTful backend service extending the Production E-Commerce Engine with secure media and file management capabilities. This project demonstrates how to handle `multipart/form-data` requests, validate uploaded files, and serve static assets in ASP.NET Core.

## 🚀 Key Features Implemented

- **Decoupled File Management (`IFileService`):** Isolated file I/O operations (`FileStream`, `IWebHostEnvironment`) into a dedicated service following SOLID principles, making it easy to switch from local storage to cloud providers (AWS S3 / Azure Blob) in the future.
- **File Security & Validation:** Enforced strict extension whitelisting (`.jpg`, `.jpeg`, `.png`, `.webp`), maximum file size limits (5 MB), and unique `Guid`-based file renaming to prevent filename collisions and malicious uploads.
- **Static File Serving:** Configured `wwwroot` and ASP.NET Core's `UseStaticFiles()` middleware to serve uploaded product images directly via relative URLs.
- **Multipart Form Data Binding:** Utilized `[FromForm]` attributes to accept both structured product metadata and binary `IFormFile` uploads in a single request.
- **Core E-Commerce Capabilities:** Retains data pagination (`Skip`/`Take`), real-time currency conversion (`HttpClient`), and standardized `ServiceResult<T>` responses.

## 📊 Database Schema (PostgreSQL)

- **Users:** `Id` (PK), `UserName`, `Email`
- **Products:** `Id` (PK), `Name`, `Price`, `StockQuantity`, `ImageUrl`
- **Carts:** `Id` (PK), `UserId` (FK), `IsActive`
- **CartItems:** `Id` (PK), `CartId` (FK), `ProductId` (FK), `Quantity`

## 🛠️ Endpoints Overview

### Products (`/api/products`)

- `GET /api/products?pageNumber={x}&pageSize={y}` - Retrieves paginated product listings including their image URLs.
- `POST /api/products/create-product` - Accepts `multipart/form-data` (`[FromForm]`) to upload a product image and create a new product record.
- `POST /api/products/create-user` - Creates a mock user for testing.

### Carts (`/api/carts`)

- `POST /api/carts/addtocart` - Adds items to the user's active cart.
- `GET /api/carts/allcarts/{userId}` - Retrieves the active cart with calculated AZN and dynamically converted USD totals.
- `POST /api/carts/checkout/{userId}` - Processes checkout and deducts inventory.

## ⚙️ How to Run

1. Clone the repository and navigate to `ECommerce_Media_Service`.
2. Ensure a `wwwroot` folder exists in the project root directory.
3. Update the `Default` PostgreSQL connection string in `appsettings.json`.
4. Open the terminal and run `dotnet restore` to install required packages.
5. Run `dotnet ef database update` to apply the `ImageUrl` schema migration.
6. Execute `dotnet run` and test file uploads via Swagger (`multipart/form-data`).
