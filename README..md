# 📦 CraftIQ - Inventory & Order Management API

**CraftIQ** is a robust, scalable RESTful API built with **ASP.NET Core** designed to streamline inventory tracking, product categorization, order processing, and stock transaction logging. 

This project emphasizes clean code, maintainability, and separation of concerns by implementing **Clean / Multi-Layered Architecture** alongside modern design patterns such as the **REPR (Request-Endpoint-Response) Pattern**, **Specification Pattern**, and **Generic Repository**.

---

## 🏗️ Architecture & Project Structure

The solution is decoupled into **5 distinct projects** to ensure that business logic, data access, and presentation layers remain completely independent:

```text
CraftIQ.sln
├── 🌐 CraftIQ                         # Presentation Layer (API & REPR Endpoints)
├── 🧠 CraftIQ.Inventory.Core          # Domain Layer (Entities, Interfaces, Specifications)
├── 🗄️ CraftIQ.Inventory.Infrastructre # Data Access Layer (EF Core, DbContext, Repositories, Migrations)
├── ⚙️ CraftIQ.Inventory.Services      # Application Layer (Business Logic, Services, Factories)
└── 📦 CraftIQ.Inventory.Shared        # Shared Layer (DTOs & Operation Contracts)
```

---

## 🚀 Key Design Patterns & Principles

* **REPR Pattern (Request-Endpoint-Response):** Instead of bloated traditional controllers (Fat Controllers), endpoints are structured around single operations (`Create`, `Read`, `Update`, `Delete`). Each endpoint encapsulates its own handler, request model, and response model (e.g., `Order.cs`, `Order.CreateRequest.cs`, `Order.CreateResponse.cs`), strictly adhering to the **Single Responsibility Principle (SRP)**.
* **Generic Repository Pattern:** Centralizes common CRUD data access operations in `InventoryRepository` to adhere to the DRY (Don't Repeat Yourself) principle.
* **Specification Pattern:** Encapsulates complex LINQ queries, filtering, and data inclusion logic inside reusable classes (e.g., `ReadByIdSpecification`, `ReadSpecification`) within the `Core` layer.
* **Factory Pattern:** Used in the `Services` layer (e.g., `InventoryFactory`) to handle complex object creation and mapping logic cleanly.
* **Shared Contracts (DTOs):** Protects core domain entities by exposing strictly typed contracts (`OrderContract`, `OrderOperationContract`, etc.) across layer boundaries.

---

## 📌 API Endpoints Overview

The API is fully documented and interactive via **Swagger UI**. Below is a summary of the available modules and routes:

### 1. 🏭 Inventory
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/Inventories` | Retrieve all inventory records |
| `GET` | `/Inventories/{InventoryId}` | Retrieve a specific inventory by ID |
| `POST` | `/Inventories/create` | Create a new inventory record |
| `PUT` | `/Inventories/{InventoryId}` | Update an existing inventory record |
| `DELETE` | `/Inventories/{InventoryId}` | Delete an inventory record |

### 2. 🛍️ Product & Category
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/Products` | Retrieve all products |
| `GET` | `/Products/{ProductID}` | Retrieve a specific product by ID |
| `GET` | `/Products/Category/{CategoryId}` | Retrieve all products under a specific category |
| `GET` | `/get-single-by-category-id` | Retrieve a single product by category ID |
| `POST` | `/Products/Create` | Create a new product |
| `PUT` | `/Products/{ProductId}` | Update product details |
| `PUT` | `/Products/{ProductId}/Category/{CategoryId}` | Assign or update a product's category |
| `DELETE` | `/Products/{ProductId}` | Delete a product |

### 3. 🛒 Order
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/Orders` | Retrieve all orders |
| `GET` | `/Orders/{OrderId}` | Retrieve a specific order by ID |
| `POST` | `/Orders/create` | Create a new customer order |
| `PUT` | `/Orders/Update/{OrderId}` | Update an existing order |
| `DELETE` | `/Orders/Delete/{OrderId}` | Delete an order |

### 4. Receipt / Order Details
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/OrderDetails` | Retrieve all order detail items |
| `POST` | `/OrderDetails/create` | Add line items/details to an order |
| `PUT` | `/OrderDetails/Update/{OrderDetailsId}` | Update specific order line item details |
| `DELETE` | `/OrderDetails/Delete/{OrderDetailId}` | Remove an item from order details |

### 5. 🔄 Transactions
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/Transactions` | Retrieve all inventory transactions |
| `GET` | `/Transactions/{TransactionId}` | Retrieve a specific transaction by ID |
| `POST` | `/Transactions/create` | Log a new inventory transaction (stock in/out) |
| `PUT` | `/Transactions/Update/{transactionId}` | Update a transaction record |
| `DELETE` | `/Transactions/Delete/{TransactionId}` | Delete a transaction record |

---

## 🛠️ Tech Stack

* **Framework:** .NET / ASP.NET Core Web API
* **Language:** C#
* **ORM:** Entity Framework Core (Code-First Approach & Migrations)
* **Database:** Microsoft SQL Server
* **API Documentation:** Swagger / OpenAPI

---

## ⚙️ Getting Started (Local Development)

Follow these steps to run the project locally:

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) installed
* SQL Server (LocalDB, Express, or Developer Edition)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YOUR-USERNAME/CraftIQ.git
   cd CraftIQ
   ```

2. **Configure the Database Connection:**
   Open `appsettings.json` in the `CraftIQ` API project and update the connection string to point to your local SQL Server instance:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=CraftIQDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. **Apply Entity Framework Migrations:**
   Run the following command from the solution root directory (or via Package Manager Console):
   ```bash
   dotnet ef database update --project CraftIQ.Inventory.Infrastructre --startup-project CraftIQ
   ```

4. **Run the Application:**
   ```bash
   dotnet run --project CraftIQ
   ```

5. **Explore the API:**
   Open your browser and navigate to `https://localhost:<port>/swagger` to test the endpoints directly.

---

## 🤝 Contributing & Feedback

Contributions, issues, and architecture discussions are always welcome! Feel free to fork the repository or open an issue to share your feedback.