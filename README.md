Steps to run the solution
=====
- [x] Run dotnet restore at the root level of the project to restore packages.
- [x] Run cd DataAccess to move to DataAccess project.
- [x] Create the database with initial migration running dotnet ef database update
- [x] Go up and move to directory Net_Core_Seed of the solution. Then run the project with dotnet run
- [x] Open browser and go to http://localhost:53724/swagger/ to see the available endpoints.

Architecture
=====
- [x] Multiple tiers (API, BusinessLogin, DataAccess and Entities)
- [x] Follows sinlgeton pattern for each tier. https://en.wikipedia.org/wiki/Singleton_pattern
- [x] Follows the Factory pattern for each tier. Each tier has its own factory. https://en.wikipedia.org/wiki/Factory_method_pattern

Features
=====
- [x] Framework .NET Core 2.0
- [x] Swagger to document the api endpoints. More information here: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=netcore-cli
- [x] Entity Framework Core as ORM.
- [x] .NET Core Identity to manage users, roles and social login. (social login configuration is not included in this starter kit.)
- [x] Fluent Validation (https://github.com/JeremySkinner/FluentValidation/wiki)
- [x] Automapper. More information here: http://automapper.org/
- [x] JWT Tokens using Microsoft.AspNetCore.Authentication.JwtBearer package
- [x] Uses SendGrid for email service. More information: https://sendgrid.com/
- [x] .NET Core Logging and Loggly as 3rd provider. More information about .net core integrated logging here: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?tabs=aspnetcore2x . More information about Loggly here: https://www.loggly.com/
