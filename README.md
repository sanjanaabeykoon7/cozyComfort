# CozyComfort Supply Chain Management System

## Overview

CozyComfort is a comprehensive supply chain management application designed for a blanket manufacturing and distribution company. It facilitates seamless interactions among manufacturers, distributors, sellers, and administrators through a web service backend and a Windows Forms desktop application frontend. The system supports user authentication, inventory management, order processing, and stock requests, ensuring efficient operations across the supply chain.

The repository includes the source code for the ASP.NET web service, the Windows Forms application, database scripts, and supporting files.

## Features

- **User Management (Admin Role)**:
  - View, add, update, and delete user accounts.
  - Role-based access control for Admin, Manufacturer, Distributor, and Seller.

- **Blanket Management (Manufacturer Role)**:
  - Add, update, and delete blanket products.
  - View and manage (Approve/Reject) stock requests from distributors.

- **Stock and Order Management (Distributor Role)**:
  - Manage personal stock inventory.
  - View and fulfill orders from sellers.
  - Request stock from manufacturers.
  - Cancel pending orders.

- **Order Placement and Stock Management (Seller Role)**:
  - Manage personal stock inventory.
  - View available blankets from manufacturers.
  - Place orders with distributors.
  - Check order status.

- **Security**:
  - Role-based authentication.

- **Database Integration**:
  - SQL Server for persistent storage of users, blankets, stocks, orders, and requests.

## Technologies Used

- **Backend**: ASP.NET Web Service (ASMX), C# (.NET Framework 4.7.2)
- **Frontend**: Windows Forms (WinForms) Application
- **Database**: SQL Server
- **Dependencies**:
  - Microsoft.CodeDom.Providers.DotNetCompilerPlatform (v2.0.1)
  - Newtonsoft.Json (v13.0.1)
  - System.Runtime.Serialization.Primitives (v4.3.0)
- **Tools**: Visual Studio 2022

## Prerequisites

- Visual Studio 2017 or higher with .NET Framework support.
- SQL Server (Express or full edition).
- Internet Information Services (IIS) for hosting the web service (optional for local development).

## Installation and Setup

### 1. Clone the Repository
```bash
git clone https://github.com/sanjanaabeykoon7/cozyComfort.git
```

### 2. Database Setup
- Open SQL Server Management Studio (SSMS) OR use Server Explorer in Visual Studio.
- Create a new database (e.g., `CozyComfortDB`).
- Execute the SQL scripts in the `DB/` directory in the following order:
  1. `SQLQuery2.sql` (Users table).
  2. `SQLQuery1.sql` (Blankets and Orders tables).
  3. `SQLQuery3.sql` (Stock and StockRequests tables).
- Update the connection string in `CozyComfortSystem/Data/DataAccessLayer.cs` to point to your database:
  ```csharp
  private static string connectionString = "Server=your_server;Database=CozyComfortDB;Trusted_Connection=True;";
  ```

### 3. Build the Solution
- Open `CozyComfortSystem.sln` in Visual Studio.
- Restore NuGet packages (right-click solution > Restore NuGet Packages).
- Build the solution (Build > Build Solution).

### 4. Configure the Web Service
- The web service is in the `CozyComfortSystem` project.
- Set it as the startup project if testing locally.
- For production, deploy to IIS and ensure the service URL is accessible.

### 5. Run the Windows Application
- Set `CozyComfortWindowsApp` as the startup project.
- Update the web service reference in the Windows app if the service URL changes:
  - Right-click "Web References" > Update Web Reference.
- Run the application (F5).

## Usage

1. **Login**:
   - Launch the Windows app.
   - Enter username and password.
   - The system redirects to the appropriate dashboard based on the user's role.

2. **Dashboards**:
   - **Admin Dashboard**: Manage users.
   - **Manufacturer Dashboard**: Manage blankets and stock requests.
   - **Distributor Dashboard**: Manage stock, view seller orders, and request stock.
   - **Seller Dashboard**: Manage stock, place orders, and check order status.

3. **Example Workflow**:
   - Manufacturer adds a blanket.
   - Distributor requests stock for the blanket.
   - Manufacturer approves the request, updating distributor's stock.
   - Seller places an order for the blanket.
   - Distributor fulfills the order, updating seller's stock.

## Project Structure

- **CozyComfortSystem/**: Web service project with controllers, models, and data access layer.
- **CozyComfortWindowsApp/**: Windows Forms app with dashboards for each role.
- **DB/**: SQL scripts for database schema.
- **packages/**: NuGet package dependencies.

---
