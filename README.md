# Clean Architecture ASP.NET Application


## Frameworks and Libraries
- [ASP.NET Core 2.2](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2);
- [MediatR](https://github.com/jbogard/MediatR) (mediator pattern implementation for .NET);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (for data access);
- [Entity Framework In-Memory Provider](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory) (for testing purposes);

## How to Test

First Add you Connection stirng for the database connection `CleanArchitecture.API/appsettings.json`

```
 "ConnectionStrings": {
   "DefaultConnection": "ADD YOUR CONNECTION STRING HERE"
 }
```

