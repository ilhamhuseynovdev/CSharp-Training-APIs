# 🛒 Mini E-Commerce Cart API

A RESTful backend service simulating a shopping cart and checkout process for an e-commerce platform. This project focuses on Many-to-Many database relationships, inventory management, and aggregate calculations within Data Transfer Objects (DTOs).

## 🚀 Features
- **Product & Inventory Management:** Create and list products while tracking available stock quantities.
- **Dynamic Cart System:** Add products to an active cart, automatically grouping duplicate items and updating their quantities instead of creating duplicate records.
- **Checkout Logic:** Validates stock availability, deducts purchased quantities from inventory upon checkout, and deactivates the completed cart.
- **Relational Mapping:** Implements a Many-to-Many relationship between `Cart` and `Product` using `CartItem` as a join table in Entity Framework Core.
- **Data Formatting:** Uses DTOs to return structured JSON responses, including on-the-fly calculations for item totals and grand totals.

## 📊 Database Schema (PostgreSQL)
- **Users:** `Id` (PK), `UserName`, `Email`
- **Products:** `Id` (PK), `Name`, `Price`, `StockQuantity`
- **Carts:** `Id` (PK), `UserId` (FK), `IsActive`
- **CartItems:** `Id` (PK), `CartId` (FK), `ProductId` (FK), `Quantity`

## 🛠️ Endpoints Overview

### Products & Users (`/api/products`)
- `GET /api/products` - Retrieves all available products.
- `POST /api/products/create-product` - Creates a new product.
- `POST /api/products/create-user` - Creates a mock user for testing purposes.

### Carts (`/api/carts`)
- `POST /api/carts/addtocart` - Adds a specific quantity of a product to a user's active cart.
- `GET /api/carts/active-cart/{userId}` - Retrieves the user's active cart items along with the calculated total prices.
- `POST /api/carts/checkout/{userId}` - Finalizes the purchase, deducts stock quantities, and marks the cart as inactive.

## ⚙️ How to Run

1. Clone the repository.
2. Update the PostgreSQL connection string in `appsettings.json`.
3. Download packages: FluentValidation.AspNetCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Tools, Npgsql.EntityFrameworkCore.PostgreSQL
4. Open "Package Manager Console" and run "update-database"
5. Run the Code.