
# NetBlog Backend

Project created as a portfolio idea, implementing TDD (integration and unit tests), MediatR, FluentValidation, PostgreSql and many more!

## Features

- Clean architecture
- Authentication/Authorization JWT Tokens
- MediatR
- FluentValidation
- *this section will be updated along with project creation*


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
Creating migration:
```bash
dotnet ef migrations add "MigrationName" -s NetBlog.Api -p NetBlog.Infrastructure --context ApplicationDbContext --output-dir Persistence/Migrations --verbose
```

Removing last migration:
```bash
dotnet ef migrations remove -s NetBlog.Api -p NetBlog.Infrastructure --context ApplicationDbContext 
```
Revert last migration:
```bash
dotnet ef database update "PreviousMigrationName" -s NetBlog.Api -p NetBlog.Infrastructure --context ApplicationDbContext
dotnet ef migrations remove -s NetBlog.Api  -p NetBlog.Infrastructure --context ApplicationDbContext
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

