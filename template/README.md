# Reusable DDD ASP.NET Core Template

This is a template for creating a C# / .NET 10 / ASP.NET Core project following Domain-Driven Design (DDD) principles, CQRS (Command only), and layered architecture.
It is based on the reference exercise, providing a reusable foundation for similar exams.

## Tech stack

- .NET 10 (`net10.0`)
- Entity Framework Core 10.0.8
- MySql.EntityFrameworkCore 10.0.7 (Oracle MySQL provider)
- Swashbuckle.AspNetCore 10.2.0
- Localization via `Resources/*.resx`

## Substitution Guide

To use this template for a new exercise, copy all contents to your actual project folder and replace the placeholders in file names and file contents according to the table below.

| Placeholder | Description | Example (Hertz) | Example (Maquinarias) |
|---|---|---|---|
| `pc217953u20231e795.API` | Name of the C# project (e.g. `pc2<NRC>u<código-estudiante>`) | `pc27414u201621873.API` | `pc2_7420_u20231f226` |
| `{DatabaseSchema}` | Name of the database schema / context | `Hertz` | `Maquinarias` |
| `{BoundedContext}` | Name of the main bounded context | `services` | `sale` |
| `{Entity}` | Name of the main aggregate root entity (PascalCase) | `RentalOrder` | `Bill` |
| `{Entities}` | Plural name of the main entity (PascalCase) | `RentalOrders` | `Bills` |
| `{EntityId}` | Name of the primary key property for the entity | `RentalOrderId` | `BillNumber` |
| `{EEnum}` | Name of the enumeration type | `EVehicles` | `EService` |
| `{ValueObject}` | Name of the owned value object | `Address` | `Invoice` |
| `{UrlSegment}` | URL segment for the REST endpoint (kebab-case) | `rental-orders` | `bills` |
| `{AuthorName}` | Your name to put in XML documentation `<remarks>` | `John Doe` | `Alex Sanchez Ponce` |

## Database connection

Update `appsettings.json` with your local MySQL credentials. The default template uses:

```json
"DefaultConnection": "server=localhost;user=root;password=123456789;database={DatabaseSchema};"
```

Replace `{DatabaseSchema}` with your schema name (e.g. `Hertz`) and adjust `password` if needed.

## Step-by-Step Usage Instructions

1. **Copy the Template:** Copy the entire `template/` folder structure to a new directory named after your project.
2. **Rename Files and Folders:**
   - Rename `template/pc217953u20231e795.API.csproj` to your actual project name (e.g. `pc27414u201621873.API.csproj`).
   - Rename `template/{BoundedContext}/` to your bounded context (e.g. `services/`).
   - Rename files like `{Entity}.cs`, `{EEnum}.cs`, etc., according to the table above.
3. **Search and Replace Content:**
   - Replace all placeholders (`pc217953u20231e795.API`, `{Entity}`, `{DatabaseSchema}`, etc.) with your actual values.
4. **Fill in the Details:**
   - **Properties:** Open `{Entity}.cs`, `Create{Entity}Resource.cs`, and `{Entity}Resource.cs` and add exercise-specific properties.
   - **Value Object:** Open `{ValueObject}.cs` and add its properties.
   - **Enum:** Open `{EEnum}.cs` and define its members.
   - **Business Rules:** Implement validation in `{Entity}CommandService.cs`.
   - **Entity Configuration:** Map columns in `{Entity}Context.cs`.
5. **Run the Project:**
   - Ensure MySQL is running and the database exists (or will be created via `EnsureCreated()`).
   - Run `dotnet restore`, `dotnet build`, and `dotnet run`.
   - Open Swagger UI at `http://localhost:5105/swagger`.

## Author

Generated from reusable template.
