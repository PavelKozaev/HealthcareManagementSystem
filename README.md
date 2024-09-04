# Healthcare Management System API

A RESTful Web API built with ASP.NET Core for managing doctors and patients in a healthcare system. The API provides endpoints for CRUD operations, with support for pagination, sorting, and related entity handling.

## Table of Contents

- [Requirements](#requirements)
- [Setup Instructions](#setup-instructions)
- [Database Migrations](#database-migrations)
- [API Endpoints](#api-endpoints)
- [Technologies Used](#technologies-used)

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any other IDE that supports .NET 8 development

## Setup Instructions

	1. **Clone the Repository:**	
	
    git clone https://github.com/PavelKozaev/healthcare-management-system.git
    cd healthcare-management-system

	2. **Configure the Database:**

	Update the DefaultConnection string in the appsettings.json file located in the HealthcareManagementSystem.API project with your SQL Server connection details.
	
	"ConnectionStrings": {
	"DefaultConnection": "Server=YOUR_SERVER;Database=HealthcareDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}

	3. **Run the Application:**

	Open the solution in Visual Studio and set HealthcareManagementSystem.API as the startup project. Build and run the project.

	The application will automatically apply any pending migrations to the database at startup.

## Database Migrations

    The application uses Entity Framework Core for database management. Migrations are automatically applied when the application starts. If you need to add a new migration manually, follow these steps:

	1. Add Migration:

	dotnet ef migrations add <MigrationName> --project HealthcareManagementSystem.Infrastructure

	2. Update Database:

	dotnet ef database update --project HealthcareManagementSystem.Infrastructure

## API Endpoints

	The API provides endpoints for managing doctors and patients, including support for pagination, sorting, and CRUD operations. Below are the available endpoints:

	DoctorController

	GET /api/Doctor?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={field}: Get a paginated and sorted list of doctors.
	GET /api/Doctor/{id}: Get a doctor's details by ID (returns an editable object with related IDs).
	POST /api/Doctor: Add a new doctor.
	PUT /api/Doctor/{id}: Update an existing doctor.
	DELETE /api/Doctor/{id}: Delete a doctor by ID.

	PatientController

	GET /api/Patient?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={field}: Get a paginated and sorted list of patients.
	GET /api/Patient/{id}: Get a patient's details by ID (returns an editable object with related IDs).
	POST /api/Patient: Add a new patient.
	PUT /api/Patient/{id}: Update an existing patient.
	DELETE /api/Patient/{id}: Delete a patient by ID.

## Technologies Used

	ASP.NET Core 6.0 - Web API framework
	Entity Framework Core 6.0 - ORM for database access
	SQL Server - Relational database management system
	AutoMapper - Object-Object Mapper for DTOs
	Swagger/OpenAPI - API documentation