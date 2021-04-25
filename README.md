# Asp.Net 5.0 CQRS & Specification Patterns Implamentation Sample Project
### Architecture & Patterns

- Clean Architecture
- CQRS
- Event Sourcing
- MediatR
- Spesification
- Generic Repository

### Features

- [Asp.Net 5.0](http://www.dot.net "Asp.Net 5.0")
- [Entitity Framework 6.0](https://docs.efproject.net/en/latest/ "Entitity Framework 6.0")
- [Auto Mapper](https://automapper.org/ "Auto Mapper")
- [Fluent Validation](https://fluentvalidation.net/ "Fluent Validation")
- [MediatR](https://github.com/jbogard/MediatR/ "MediatR")
- [Swagger Open API implementation] (https://swagger.io/)

## Getting Started
### Pre-requisites
1. .Net 5.0 SDK
2. Visual studio 2019 OR VSCode with C# extension

### Database Configuration
- SQLite just using for development prurposes so if you wanto to create a solution for production you should change it and remove or change conditions about sqlite in ApplicationDbContext.

### Database Migrations
- Migration:
```sh
  cd OFG.CqrsSample.API
  dotnet ef migrations add MIGRATIN_NAME -o Migrations -p ..\OFG.CqrsSample.Infrastructure -c ApplicationDbContext
```
- When you run OFG.CqrsSample.API, DB will be automatically updated.

### Support
If you are having problems, please let us know by raising a new issue.

### License
This project is licensed with the GNU General Public License v3.0 license.

