# 🛡️ Identity & JWT Authentication API

This project demonstrates a production-ready, highly secure user authentication and authorization system using ASP.NET Core Identity and JSON Web Tokens (JWT). It strictly adheres to the N-Tier Architecture and ServiceResult pattern established in previous modules.

## 🚀 Features & Implementation Details

- **ASP.NET Core Identity:** Fully integrated custom `AppUser` model deriving from `IdentityUser`, managed via `IdentityDbContext` to handle secure password hashing, salt generation, and user validation automatically.
- **JWT Generation & Validation:**
  - Generates secure, signed access tokens upon successful login using `SymmetricSecurityKey` and `HmacSha256` encryption.
  - Custom claims injection (`NameIdentifier`, `Email`, `FullName`, `Jti`) to embed user data securely within the token payload.
  - Enforced token validation parameters in `Program.cs` ensuring strict checks on `Issuer`, `Audience`, `Lifetime`, and `SigningKey`.
- **Clean Architecture Principles:**
  - Controllers (`AuthController`) remain razor-thin, routing requests directly to the `AuthService`.
  - The `AuthService` handles all complex logic: user existence checks, `UserManager` interactions, error message aggregation, and `JwtSecurityToken` construction.
- **Robust Validation:** `FluentValidation` is utilized to enforce strict password policies (length, matching confirm password) and email formatting at the DTO level before hitting the database.
- **Unified Error Handling:** Utilizes the custom `ServiceResult<T>` wrapper to gracefully handle identity errors (e.g., password too weak, email already taken) and return them as structured JSON responses via the `CustomBaseController`.

## 🛠️ Endpoints Overview

### Authentication (`/api/auth`)

- `POST /api/auth/register` - Accepts user details (FullName, UserName, Email, Password, ConfirmPassword), validates them, and securely creates a new user via `UserManager`.
- `POST /api/auth/login` - Authenticates user credentials. Upon success, returns a structured JSON object containing a bearer `Token` string and its `ExpireDate`.

## ⚙️ How to Run

1. Clone the repository.
2. Navigate to `Identity_JWT_Auth_API`.
3. Open `appsettings.json` and configure:
   - Your PostgreSQL `Default` connection string.
   - The `Jwt` section with a highly secure `Key` (min. 16 characters), `Issuer`, `Audience`, and `ExpireMinutes`.
4. Open the terminal and run `dotnet restore` to fetch all required NuGet packages (including Npgsql, Microsoft.AspNetCore.Authentication.JwtBearer, and FluentValidation).
5. Run `dotnet ef database update` to generate the Identity tables in your PostgreSQL database.
6. Execute `dotnet run` and test the `/register` and `/login` endpoints via Swagger.
