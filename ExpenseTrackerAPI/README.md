# 💰 Expense Tracker API

A RESTful backend service built for tracking personal incomes, expenses, and categorizing financial transactions. Designed as the first step of my transition from MVC to modern Web APIs.

## 🚀 Features

- **Category Management:** Create, update, delete, and list expense categories with duplicate name prevention.
- **Expense Management:** Track individual expenses linked to specific categories using relational database mapping.
- **Data Validation:** Robust request validation implemented via **FluentValidation**.
- **Relational Mapping:** One-to-Many relationship configuration between `Category` and `Expense` using Entity Framework Core.
- **DTO Pattern:** Clean separation of data models and API response/request objects (Data Transfer Objects).

## 📊 Database Schema (PostgreSQL)

- **Categories:** `Id` (PK), `Name`
- **Expenses:** `Id` (PK), `Title`, `Amount`, `Date`, `CategoryId` (FK)

## 🛠️ Endpoints Overview

### Categories (`/api/categories`)

- `GET /api/categories` - Retrieves all categories.
- `POST /api/categories` - Creates a new category.
- `PUT /api/categories/{id}` - Updates an existing category.
- `DELETE /api/categories/{id}` - Deletes a category.

### Expenses (`/api/expenses`)

- `GET /api/expenses` - Retrieves all expenses with related category details.
- `POST /api/expenses` - Creates a new expense.
- `PUT /api/expenses/{id}` - Updates an existing expense.
- `DELETE /api/expenses/{id}` - Deletes an expense.

## ⚙️ How to Run

1. Clone the repository.
2. Update the PostgreSQL connection string in `appsettings.json`.
3. Download packages: FluentValidation.AspNetCore ,Microsoft.EntityFrameworkCore ,Microsoft.EntityFrameworkCore.Tools ,Npgsql.EntityFrameworkCore.PostgreSQL
4. Open "Package Manager Console" and run "update-database"
5. Run the Code.
