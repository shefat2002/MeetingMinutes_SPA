# Meeting Minutes - Single Page Application

A comprehensive meeting minutes management system built with ASP.NET Core 8.0 following Clean Architecture principles. This is a Single Page Application.

## 🏗️ Architecture

This project follows **Clean Architecture** principles with clear separation of concerns:

### Project Structure

```
MeetingMinutes.Web/          # Presentation Layer (ASP.NET Core MVC)
├── Controllers/             # MVC Controllers
├── Views/                   # Razor Views
├── Models/                  # View Models
├── wwwroot/                 # Static files (CSS, JS, images)
└── Program.cs              # Application entry point

MeetingMinutes.Application/  # Application Layer
├── Services/               # Business logic implementation
└── ServiceInterface/       # Service contracts

MeetingMinutes.Domain/       # Domain Layer
├── Entities/               # Domain entities
└── RepositoryInterfaces/   # Repository contracts

MeetingMinutes.Infrastructure/ # Infrastructure Layer
├── Repositories/           # Data access implementation
└── DBContext/             # Database context (Dapper)

DatabaseQueries/            # Database scripts
└── database_DDL.sql       # Database schema
```

### Technology Stack

- **Framework**: ASP.NET Core 8.0
- **ORM**: Dapper for data access
- **Database**: SQL Server
- **Frontend**: MVC with Razor Views, Bootstrap, jQuery
- **Architecture**: Clean Architecture with Repository Pattern
- **Dependency Injection**: Built-in ASP.NET Core DI

## 📋 Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🛠️ Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/shefat2002/MeetingMinutes_SPA
cd MeetingMinutes_SPA
```

### 2. Database Setup
```bash
# Execute the database script
sqlcmd -S (localdb)\MSSQLLocalDB -i DatabaseQueries/database_DDL.sql
```

### 3. Configure Connection String
Update the connection string in `MeetingMinutes.Web/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<Your-Server>;Database=MeetingMinutesDB;Trusted_Connection=true;"
  }
}
```

### 4. Restore Dependencies
```bash
dotnet restore
```

### 5. Build the Solution
```bash
dotnet build
```

### 6. Run the Application
```bash
cd MeetingMinutes.Web
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## 📊 Database Schema

The application uses the following main entities:

- **Corporate_Customer_Tbl**: Corporate customer information
- **Individual_Customer_Tbl**: Individual customer information  
- **Products_Service_Tbl**: Products and services catalog
- **MeetingMinutes_Master_Tbl**: Main meeting records
- **MeetingMinutes_Details_Tbl**: Detailed meeting items and services

## 🎯 Usage

1. **Navigate to the application** in your web browser
2. **Select customers** (Corporate or Individual)
3. **Add products/services** to the system
4. **Create meeting minutes** with:
   - Meeting date and time
   - Meeting location
   - Agenda and discussion points
   - Decisions made
   - Attendees from both client and host sides
5. **Associate products/services** with meeting minutes
6. **View and manage** all meeting records

## 🧪 Development

### Project Dependencies

Key NuGet packages used:
- `Dapper` (2.1.66) - Micro ORM for data access
- `Microsoft.EntityFrameworkCore.SqlServer` (8.0.17) - SQL Server provider
- `Microsoft.AspNetCore.Mvc.NewtonsoftJson` (8.0.17) - JSON serialization
- `Microsoft.jQuery.Unobtrusive.Validation` (4.0.0) - Client-side validation


