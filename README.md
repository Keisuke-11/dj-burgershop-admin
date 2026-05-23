# DJ's Burger Shop - Admin Panel

A VB.NET WinForms application for managing the overall burger shop system, including menu items, pricing, employee payroll, customer history, and overall store reports.

## 🛠️ Setup Instructions

### 1. Database Setup
1. Ensure you have **MySQL** or **MariaDB** running (e.g., via XAMPP).
2. Create a new database named `dj_burgershop`.
3. Import the `Admin/burger_system_schema.sql` database file.

### 2. Configuration Setup
1. Locate the build directory or root folder.
2. Copy `db_config.ini.example` and rename it to `db_config.ini`.
3. Fill in your MySQL details:
   ```ini
   [Database]
   Server=localhost
   Database=dj_burgershop
   Uid=root
   Pwd=YOUR_PASSWORD_HERE
   ```
4. If you run the application and the connection fails, use the configuration setup interface in the app to configure and test the connection automatically.
