# PC217953.U20231E795.Clerky.Platform

A RESTful API built with ASP.NET Core (.NET 10) that supports Stripe Atlas operations for managing Startup Incorporations.

## What it does

This API lets you register a new Startup Incorporation by sending a POST request. It stores the incorporation data in a MySQL database and returns the saved record including its generated ID.

## Endpoint

| Method | URL | Description |
|--------|-----|-------------|
| POST | `/api/v1/startup-incorporations` | Create a new Startup Incorporation |

### Request body example

```json
{
  "incorporationIdentifier": "550e8400-e29b-41d4-a716-446655440000",
  "founderId": "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
  "periodStartDate": "2025-01-01",
  "periodCompletionDate": "2025-12-31",
  "registeredCapitalValue": 50000.00,
  "registeredCapitalCurrency": "USD",
  "status": "Draft",
  "notes": "Initial incorporation request"
}
```

### Response example (201 Created)

```json
{
  "id": 1,
  "incorporationIdentifier": "550e8400-e29b-41d4-a716-446655440000",
  "founderId": "6ba7b810-9dad-11d1-80b4-00c04fd430c8",
  "periodStartDate": "2025-01-01",
  "periodCompletionDate": "2025-12-31",
  "registeredCapitalValue": 50000.00,
  "registeredCapitalCurrency": "USD",
  "status": "Draft"
}
```

## Business rules

- The `incorporationIdentifier` must be unique across all incorporations.
- The `periodCompletionDate` must be greater than `periodStartDate`.
- The `registeredCapitalValue` must be greater than or equal to zero.
- The `registeredCapitalCurrency` must not be empty or blank.
- The `status` defaults to `Draft` if not specified.

## Tech stack

- .NET 10 / ASP.NET Core
- Entity Framework Core 10 with MySQL (`atlas_wa` schema)
- Swagger / OpenAPI (available at `/swagger` in development)
- Localization support: English (`en`, `en-US`) and Spanish (`es`, `es-PE`) via `Accept-Language` header

## How to run

1. Make sure MySQL is running and a schema named `atlas_wa` is available (or will be created automatically).
2. Update the connection string in `appsettings.json` if needed.
3. Run the following commands:

```bash
dotnet restore
dotnet build
dotnet run
```

4. Open Swagger UI at `http://localhost:5105/swagger`.

## Author

PC217953 U20231E795
