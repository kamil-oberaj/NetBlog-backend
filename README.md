
# NetBlog Backend

Project created as a portfolio idea, implementing TDD (integration and unit tests), MediatR, FluentValidation, PostgreSql and many more!

## Features

- Build using [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture/tree/net6.0)
- Authentication/Authorization JWT Tokens
- MediatR
- Currently 2 contexts: Business (main one), Identity and Error/logger (on its way!)


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

Creating identity migration (will not be used?):
```bash
dotnet ef migrations add "MigrationName" -s src/NetBlog.Api -p src/NetBlog.Infrastructure --context ApplicationIdentityDbContext --output-dir Persistence/Migrations/Identity --verbose
```

## Documentation

*this section will be updated soon*
[DOCS LINK](https://github.com/Sh0w3D/NetBlog-backend/wiki/Project-documentation)


## Running Tests (**tests will be added soon!🚀**)

To run tests, run the following command 

```bash
dotnet test NetBlog.Tests/NetBlog.Tests.csproj
```
## License

[MIT](https://github.com/Sh0w3D/NetBlog-backend/blob/Dev/LICENSE.md)


## Related

Related project

[NetBlog Frontend](https://github.com/Sh0w3D/NetBlog-frontend)

