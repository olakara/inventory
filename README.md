# Backend Interview Assessment

## Summary

This project is an implementation of assignment requested for AHOY. The application makes use of Clean Architecture inspired by project structure used / demo by Jason Taylor. Technologies used are:

- ASP.NET Core 6
- Entity Framework Core 6
- MediatR
- FluentValidation

## Assumptions

Since, Inventory management is a large domain. I have kept some part of the domain as simple as possible to scope the assignment.

## Running the application

The application can be started from Visual Studio / from command line. To start the application from command line follow the below steps:

1.  `dotnet build`
2.  `dotnet run --project .\src\WebAPI\WebAPI.csproj`

Notes:

- Please make sure the database connection string is correctly provided.
- A very simple seed information for the database is loaded when the migration is complete. Please refer to `ApplicationDbContextInitialiser` class.
- API can be executed from the Swagger UI or using other tools like postman.
