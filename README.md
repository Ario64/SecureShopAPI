# 🛡️ SecureShopAPI

A secure and extensible ASP.NET Core Web API for managing users, roles, authentication (JWT & Refresh Tokens), and product operations — following best practices and separation of concerns.

---

## 🔥 Features

- ✅ **User Authentication & Authorization** using **JWT** and **Refresh Tokens**
- 🔐 **Role-based Access Control (RBAC)** — only Admins can manage products
- 🔁 **API Versioning** (`v1`, `v2`)
- 🎯 **Fluent API configuration** with **EF Core**
- 🧼 **DTOs** for clean data transfer and separation of concerns
- 🗃️ **EF Core Code-First** approach with Migrations
- 🧪 **Swagger UI** integration for API testing

---

## 📦 Tech Stack

- **.NET 8 (LTS)**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server** (easily switchable to SQLite or PostgreSQL)
- **JWT Bearer Authentication**
- **Swagger / Swashbuckle**

---

## 📁 Project Structure

```bash
SecureShopAPI
│
├── Controllers        # API endpoints
├── DTOs               # Data Transfer Objects
├── Models             # Domain models
├── Data               # DbContext and migrations
├── Services           # Business logic layer
├── Repositories       # Data access layer
├── Middlewares        # Custom middleware (e.g. error handling)
├── Mappings           # AutoMapper configurations
└── Program.cs         # Application entry and configuration
