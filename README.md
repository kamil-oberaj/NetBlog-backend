
# NetBlog Backend

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
dotnet run --project NetBlogBackend.Api
```
Run with watch:
```bash
cd <Your_project_dir>/src/
dotnet watch --project NetBlogBackend.Api run
```
Build:
```bash
cd <Your_project_dir>
dotnet build NetBlogBackend.Api
```

## Migrations FROM SOLUTION DIRECTORY
Creating business migration:
```bash
dotnet ef migrations add "MigrationName" -s src/NetBlogBackend.Api -p NetBlogBackend.Infrastructure --context NetBlogBackendDbContext --output-dir Migrations --verbose
```

## Documentation

*this section will be updated soon*
[DOCS LINK](https://gitlab.phon31x.com/Sh0w3D/NetBlog-backend/-/wikis/home)

