# 🚀 .NET Backend & API Learning Journey

Welcome to my personal learning and portfolio repository! As a full-stack developer transitioning towards robust backend engineering, this repository documents my practical, step-by-step transition from monolithic architectures to modern, scalable **RESTful Web APIs**. 

**💡 Note for Recruiters & Reviewers:** 
To demonstrate my learning progression, each phase of my journey is separated into individual project folders (01 to 06+). You can track how my code evolved from basic CRUD operations in a monolithic controller to a highly decoupled **N-Tier Architecture** with **Enterprise Security** and **External API Integrations**.

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** ASP.NET Core Web API (.NET 8+)
- **ORM:** Entity Framework Core (EF Core)
- **Database:** PostgreSQL
- **Architecture:** N-Tier / Service-Repository Pattern
- **Security:** ASP.NET Core Identity & JWT Authentication
- **Validation:** FluentValidation
- **External Integrations:** HttpClientFactory
- **Version Control:** Git & GitHub

## 📂 Projects Roadmap (Step-by-Step Evolution)

| #   | Project Folder                     | Key Concepts Learned & Applied                                                                  | Status       |
| --- | ---------------------------------- | ----------------------------------------------------------------------------------------------- | ------------ |
| 01  | **Expense Tracker API**            | Basic CRUD, One-to-Many relations, and FluentValidation basics.                                 | ✅ Completed |
| 02  | **Bank Queue API**                 | Business logic implementation and state management (Enums).                                     | ✅ Completed |
| 03  | **Mini E-Commerce Cart API**       | Many-to-Many database relations and DTO-level aggregations.                                     | ✅ Completed |
| 04  | **Advanced E-Commerce (N-Tier)**   | Extracted logic from Controllers to Services, Dependency Injection, `ServiceResult<T>` pattern. | ✅ Completed |
| 05  | **Identity & JWT Auth API**        | ASP.NET Core Identity, Password Hashing, custom Claims, and JWT Bearer Token generation.        | ✅ Completed |
| 06  | **Production E-Commerce Engine**   | Data Pagination (`Skip`/`Take`) and External API Integration (`HttpClient`) for currency rates. | ✅ Completed |
| 07  | **E-Commerce Media Service**       | Handling `multipart/form-data`, uploading product images to Local `wwwroot` or Cloud Storage.   | ⏳ Planned   |
| 08  | **High-Performance API (Redis)**   | Implementing Distributed Caching with Redis to reduce external API and Database loads.          | ⏳ Planned   |
| 09  | **Background Worker Service**      | Scheduling automated background tasks (e.g., clearing unpaid carts) using Hangfire.             | ⏳ Planned   |

## 🎯 Goal

The primary objective of this repository is to build production-ready, clean-architecture-based APIs, implement enterprise-level validation, proper error handling, and master database relations to align with modern enterprise backend requirements in both local (Azerbaijan) and global software markets.

---

_Feel free to explore the code and check out individual project folders for specific documentations!_