# 🚀 Production E-Commerce Engine API

This project elevates the Advanced E-Commerce API to production-grade standards by addressing data scalability and integrating external third-party services.

## 🌟 Key Features Implemented

*   **Data Pagination (Data Optimization):** Implemented `Skip` and `Take` logic within the `ProductService`. Clients can now retrieve data in optimized chunks via query parameters, preventing memory overload and database timeouts when querying large tables.
*   **External API Integration (`HttpClient`):** Developed a `CurrencyService` utilizing C#'s `HttpClient` to fetch real-time currency exchange rates (AZN to USD) from a public API. This dynamic data is used to calculate and display the `GrandTotalUsd` in real-time within the cart response.
*   **Fail-Safe Error Handling:** Integrated `try-catch` blocks and fallback values within external HTTP requests to prevent system crashes during third-party API downtimes.
*   **Unified Response Model:** Continued use of the generic `ServiceResult<T>` pattern and `CustomBaseController` to maintain a strict, standardized JSON response structure across all endpoints.

## 🛠️ Endpoints Overview

### Products (`/api/products`)
- `GET /api/products?pageNumber={x}&pageSize={y}` - Retrieves paginated product listings (defaults to page 1, size 10).
- `POST /api/products/create-product` - Creates a new product.

### Carts (`/api/carts`)
- `POST /api/carts/addtocart` - Adds a specified quantity of an item to the user's active cart.
- `GET /api/carts/allcarts/{userId}` - Retrieves the active cart with calculated AZN and dynamically converted USD totals.
- `POST /api/carts/checkout/{userId}` - Processes the checkout, validating and deducting stock inventory.

## ⚙️ How to Run

1. Clone the repository and navigate to `06_Production_ECommerce_Engine`.
2. Update the `Default` PostgreSQL connection string in `appsettings.json`.
3. Open terminal and run `dotnet restore` to install missing packages.
4. Run `dotnet ef database update` to apply migrations.
5. Execute `dotnet run` and test the paginated endpoints and cart calculations via Swagger.