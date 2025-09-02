# Database Migration Tool

Enterprise-grade database migration and synchronization tool supporting multiple database systems with data validation, rollback capabilities, and performance optimization.

## Features

- Supports SQL Server, MySQL, and PostgreSQL.
- Uses Entity Framework Core for migrations.
- Data validation before and after migration.
- Rollback support on failure.
- Performance optimizations with batching and transactions.
- Configurable via `appsettings.json`.

## Technologies Used

- C# .NET 7
- Entity Framework Core
- SQL Server, MySQL, PostgreSQL providers
- xUnit for testing

## Prerequisites

- .NET 7 SDK installed
- Access to target databases (SQL Server, MySQL, PostgreSQL)

## Setup

1. Clone the repository:

```bash
git clone https://github.com/yourusername/DatabaseMigrationTool.git
cd DatabaseMigrationTool
