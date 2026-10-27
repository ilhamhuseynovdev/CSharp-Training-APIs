# 🚀 Advanced E-Commerce API (N-Tier Architecture)

This project is a refactored and advanced version of the `Mini E-Commerce Cart API`. It demonstrates the transition from a monolithic controller-based approach to a clean, highly decoupled **N-Tier Architecture** utilizing the **Service Layer Pattern** and **Dependency Injection**.

## 🏗️ Architectural Improvements
- **Service Layer Pattern:** Business logic (stock validation, cart calculations) has been entirely extracted from Controllers into dedicated `ProductService` and `CartService` classes.
- **Fat Models, Skinny Controllers:** Controllers now act strictly as request routers, resulting in 1-line action methods.
- **Unified Response Model:** Implemented a custom generic `ServiceResult<T>` wrapper class to standardize all API responses (Success, Failure, Data, Message, HTTP Status Codes).
- **Custom Base Controller:** Created a `CustomBaseController` to automatically intercept `ServiceResult<T>` and dynamically return appropriate HTTP status codes (200, 400, 404).
- **Response DTOs:** Replaced anonymous objects with strictly typed `CartResponseDto` to transfer complex grouped data from the Service layer to the Controller.

## 📊 Database Schema (PostgreSQL)
- **Users:** `Id` (PK), `UserName`, `Email`
- **Products:** `Id` (PK), `Name`, `Price`, `StockQuantity`
- **Carts:** `Id` (PK), `UserId` (FK), `IsActive`
- **CartItems:** `Id` (PK), `CartId` (FK), `ProductId` (FK), `Quantity`

## 🛠️ Tech Stack & Concepts
- C#, ASP.NET Core Web API
- Entity Framework Core (PostgreSQL)
- Dependency Injection (Scoped Services)
- Generic Wrappers (`ServiceResult<T>`)
- Separation of Concerns (SoC)

## ⚙️ How to Run & Setup

To run this project locally, start by cloning the repository using `git clone https://github.com/YOUR_USERNAME/DotNet-API-Journey.git` and navigate into the project directory with `cd DotNet-API-Journey/04_Advanced_ECommerce_API`. Next, configure your database connection by opening `appsettings.json` in your code editor and updating the `DefaultConnection` string with your local PostgreSQL credentials, formatted as `"DefaultConnection": "Host=localhost;Port=5432;Database=AdvancedEcommerceDb;Username=postgres;Password=your_password"`. Afterward, restore all required NuGet package dependencies by executing `dotnet restore` in your terminal. If you do not have the Entity Framework Core tools installed globally, install them via `dotnet tool install --global dotnet-ef`. Once the packages and tools are ready, apply the database migrations to automatically create the database and tables in PostgreSQL by running `dotnet ef database update`. Finally, launch the backend service using `dotnet run`, and you can test all the available endpoints through Swagger via `https://localhost:5001/swagger`.