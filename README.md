# **FenecApi - RESTful API** 🚀🔥

## **📌 Overview**
FenecApi is a clean and scalable **RESTful API** built with **.NET Core 8**, designed to manage products, orders, and categories efficiently. It follows best practices in software architecture, implementing **repository patterns, service layers, middleware for error handling, and structured logging with NLog**. The API is ready for **cloud deployment in Azure** and supports **database migrations with EF Core**.

---

## **📐 Architecture & Design Patterns**
FenecApi follows a **clean and modular architecture** to ensure maintainability and scalability:

- **Repository Pattern** - Encapsulates database access logic.
- **Service Layer** - Handles business logic and interacts with repositories.
- **Middleware** - Centralized exception handling.
- **Logging (NLog)** - Structured logging for debugging and monitoring.
- **AutoMapper** - Simplifies DTO-to-entity mapping.
- **Dependency Injection** - Ensures loose coupling between components.

---

## **📁 Folder Structure**
```
FenecApi/
│-- Configurations/         # Entity Framework configurations for models
│-- Controllers/            # API Controllers (REST endpoints)
│-- Data/                   # DbContext configuration
│-- DTOs/                   # Data Transfer Objects
│   ├── utils/              # Shared utility DTOs
│-- Extensions/             # Custom service and middleware extensions
│-- Mapping/                # AutoMapper profile configuration
│-- Middlewares/            # Global error handling middleware
│-- Migrations/             # EF Core migrations
│-- Models/                 # Entity models
│-- Repositories/           # Repository pattern implementation
│   ├── Interfaces/         # Repository interfaces
│-- SeedData/               # Database seed data
│-- Services/               # Business logic services
│   ├── Interfaces/         # Service interfaces
│-- appsettings.json        # Configuration settings
```
---

## **🛠 Technologies Used**
- **.NET Core 8** - Backend framework
- **Entity Framework Core** - ORM for database operations
- **SQL Server** - Relational database
- **NLog** - Logging
- **Swagger (NSwag)** - API documentation
- **AutoMapper** - Object mapping
- **Dependency Injection** - Loose coupling
- **Azure App Service** - Cloud deployment

---

## **⚡ Setup & Installation**
### **1️⃣ Clone the Repository**
```bash
git clone https://github.com/yourgithubusername/FenecApi.git
cd FenecApi
```

### **2️⃣ Configure the Database Connection**
Update the `appsettings.json` file with your **SQL Server connection string**:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=FenecDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```

### **3️⃣ Apply Database Migrations**
Run the following command to apply migrations and seed data:
```bash
dotnet ef database update
```

### **4️⃣ Run the API**
```bash
dotnet run
```
The API will be available at: `http://localhost:5000`

---

## **📡 API Endpoints**
### **Categories**
| Method | Endpoint            | Description                        |
|--------|--------------------|------------------------------------|
| GET    | `/api/categories`  | Retrieve all categories           |
| POST   | `/api/categories`  | Create a new category             |

### **Health Check**
| Method | Endpoint                 | Description                          |
|--------|-------------------------|--------------------------------------|
| GET    | `/api/health/db-connection` | Check database connection status    |

For a full list of endpoints, access the **Swagger UI**: `http://localhost:5000/swagger`

---

## **🔹 Error Handling & Logging**
- **Centralized Exception Handling Middleware** ensures consistent error responses.
- **NLog integration** logs all API requests, responses, and errors.
- Logs are stored in `logs/logfile.log`.

---

## **🚀 Deployment to Azure**
### **1️⃣ Set Up an Azure Web App**
- Create an **Azure App Service**.
- Configure **SQL Server Database** in Azure.

### **2️⃣ Publish to Azure**
```bash
dotnet publish -c Release -o out
az webapp deploy --resource-group YOUR_RESOURCE_GROUP --name YOUR_APP_NAME --src-path out/
```

### **3️⃣ Validate the Deployment**
- Test the **Health Check Endpoint**:
```bash
curl https://yourapp.azurewebsites.net/api/health/db-connection
```

---

## **👥 Contributing**
Feel free to **fork** this project, open **issues**, and submit **pull requests**.

---

## **📞 Contact**
- **GitHub:** [Your GitHub Profile](https://github.com/alonsoegm)
- **LinkedIn:** [Your LinkedIn Profile](https://linkedin.com/in/alonsogallegosmesen)
- **Email:** alonsoegm@gmail.com

---

### 🔥 **Enjoy Coding & Happy Deploying!** 🔥

