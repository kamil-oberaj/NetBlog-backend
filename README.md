
# NetBlog Backend [![.NET build](https://github.com/Sh0w3D/NetBlog-backend/actions/workflows/dotnet.yml/badge.svg?branch=Dev)](https://github.com/Sh0w3D/NetBlog-backend/actions/workflows/dotnet.yml)

Project created as a portfolio idea, implementing TDD (integration and unit tests), MediatR, FluentValidation, PostgreSql and many more!

## Features

- Build using [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture/tree/net6.0)
- [Authentication/Authorization JWT Tokens](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
- [PostgreSql](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/7.0.3)
- [MediatR](https://www.nuget.org/packages/MediatR)
- [AutoMapper](https://www.nuget.org/packages/AutoMapper)
- [FluentValidation](https://www.nuget.org/packages/FluentValidation)
- [XUnit](https://www.nuget.org/packages/xunit)
- [Moq](https://www.nuget.org/packages/Moq)


## Installation

Run:
```bash
cd <Your_project_dir>/src/
dotnet run --project NetBlog.Api
```
Run with watch:
```bash
cd <Your_project_dir>/src/
dotnet watch --project NetBlog.Api run
```
Build:
```bash
cd <Your_project_dir>/src/
dotnet build NetBlog.Api
```

## Migrations FROM SOLUTION DIRECTORY
Creating business migration:
```bash
dotnet ef migrations add "MigrationName" -s src/NetBlog.Api -p src/NetBlog.Infrastructure --context ApplicationDbContext --output-dir Persistence/Migrations/Business --verbose
```

## Documentation

*this section will be updated soon*
[DOCS LINK](https://github.com/Sh0w3D/NetBlog-backend/wiki/Project-documentation)


## Running Tests 🚀

To run tests, run the following command 

```bash
dotnet test
```
## License

[MIT](https://github.com/Sh0w3D/NetBlog-backend/blob/Dev/LICENSE.md)


## Related

Related project

[NetBlog Frontend](https://github.com/Sh0w3D/NetBlog-frontend)
