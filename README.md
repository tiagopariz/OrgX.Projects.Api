# Migrations

```powershell
$env:ASPNETCORE_ENVIRONMENT='Development'
dotnet ef migrations add InitialCreate --output-dir "Migrations" --project .\src\OrgX.Projects.Api.Infra --startup-project .\src\OrgX.Projects.Api.WebApi --context ProjectsDbContext --verbose
dotnet ef database update --project .\src\OrgX.Projects.Api.Infra --startup-project .\src\OrgX.Projects.Api.WebApi --context ProjectsDbContext --verbose
```

# Docker SQL Server 2019

```powershell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Local@123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04
```

## Acessando a instância do SQL Server

Serve name: seuip,1433
Authentication: SQL Server Authentication
Login: sa
Password: Local@123