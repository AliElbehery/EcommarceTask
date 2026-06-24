# EcommarceTask

A console-based **E-Commerce Data Management** application built with **C# (.NET 10)** and **Entity Framework Core**, demonstrating a full relational database design for an e-commerce domain using SQL Server.

---

## 📋 Table of Contents

- [Overview](#overview)
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Database Models](#database-models)
- [Relationships](#relationships)
- [Services](#services)
- [Getting Started](#getting-started)
- [Database Configuration](#database-configuration)
- [Running the Application](#running-the-application)

---

## Overview

EcommarceTask is a practice project that models core e-commerce entities — customers, products, categories, orders, order items, and shipping addresses — and persists them using EF Core with SQL Server. The app runs as a console application and demonstrates eager loading with `.Include()` and `.ThenInclude()` for related data retrieval.

---

## Technologies Used

| Technology | Version |
|---|---|
| .NET | 10.0 |
| Entity Framework Core | 10.0.9 |
| EF Core SQL Server | 10.0.9 |
| EF Core Tools | 10.0.9 |
| SQL Server Express | - |

---

## Project Structure

```
EcommarceTask/
├── EcommarceTask.slnx
└── EcommarceTask/
    ├── Program.cs                  # Entry point
    ├── EcommarceTask.csproj
    ├── Data/
    │   └── AppDbContext.cs         # EF Core DbContext
    ├── Model/
    │   ├── Category.cs
    │   ├── Customer.cs
    │   ├── Order.cs
    │   ├── OrderItem.cs
    │   ├── Product.cs
    │   └── ShippingAdress.cs
    ├── Configurations/
    │   ├── CategoryConfiguration.cs
    │   ├── CustomerConfiguration.cs
    │   ├── OrderConfiguration.cs
    │   ├── OrderItemConfiguration.cs
    │   ├── ProductConfiguration.cs
    │   └── ShippingAddressConfiguration.cs
    ├── Service/
    │   ├── CategoryServices.cs
    │   ├── CustomerServices.cs
    │   └── OrderServices.cs
    └── Migrations/
        └── (EF Core migration files)
```

---

## Database Models

### Customer
| Property | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| Name | string | Required, Max 100 chars |
| Email | string | Required, valid email format |
| Orders | ICollection\<Order\> | Navigation property |
| ShippingAddresses | ICollection\<ShippingAdress\> | Navigation property |

### Category
| Property | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| Name | string | Required, Max 100 chars |
| Products | ICollection\<Product\> | Navigation property |

### Product
| Property | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| Name | string | Required, Max 100 chars |
| Price | decimal | Required |
| CategoryId | int | Foreign Key |
| Category | Category | Navigation property |

### Order
| Property | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| CustomerId | int | Foreign Key |
| ShippingAddressId | int | Foreign Key |
| Items | ICollection\<OrderItem\> | Navigation property |

> Orders include a `CalculateTotalPrice()` method that sums up `Price × Quantity` for all items.

### OrderItem
| Property | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| ProductId | int | Foreign Key |
| Quantity | int | Number of units |
| OrderId | int | Foreign Key |

### ShippingAddress
| Property | Type | Notes |
|---|---|---|
| Id | int | Primary Key |
| Street | string | - |
| City | string | - |
| CustomerId | int | Foreign Key |

---

## Relationships

```
Category  ──< Product
Customer  ──< Order ──< OrderItem >── Product
Customer  ──< ShippingAddress
Order >── ShippingAddress
```

- A **Category** has many **Products**
- A **Customer** has many **Orders** and many **ShippingAddresses**
- An **Order** belongs to a **Customer**, has a **ShippingAddress**, and contains many **OrderItems**
- Each **OrderItem** references a **Product** with a quantity

---

## Services

### `CategoryServices`
- **`DisplayCategoryWithProducts()`** — loads all categories along with their related products using eager loading and prints them to the console.

### `CustomerServices`
- **`DisplayCustomerWithShippingAddresses()`** — loads all customers with their shipping addresses.
- **`DisplayCustomerWithOrdersWithItems()`** — loads all customers with their orders, order items, and each item's product (multi-level eager loading).

### `OrderServices`
- Placeholder service, ready for future order management features.

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server Express (or any SQL Server instance)
- EF Core CLI tools

```bash
dotnet tool install --global dotnet-ef
```

---

## Database Configuration

The connection string is set in `AppDbContext.cs`:

```csharp
optionsBuilder.UseSqlServer(
    "Data Source=localhost\\SQLEXPRESS;Initial Catalog=ECommarceTask;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
);
```

Update this string to match your SQL Server instance and database name if needed.

---

## Running the Application

1. **Clone the repository**
   ```bash
   git clone https://github.com/AliElbehery/EcommarceTask.git
   cd EcommarceTask
   ```

2. **Apply database migrations**
   ```bash
   cd EcommarceTask
   dotnet ef database update
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

The console will output:
- All categories with their associated products
- All customers with their shipping addresses
- All customers with their orders, items, and product details
