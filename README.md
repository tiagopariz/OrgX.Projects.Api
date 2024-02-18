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

## Acessando a inst�ncia do SQL Server

Serve name: seuip,1433
Authentication: SQL Server Authentication
Login: sa
Password: Local@123

# Refinamento


## Perguntas para refinamento de novas funcionalidades

1. Quais s�o as principais necessidades dos usu�rios que n�o est�o sendo atendidas atualmente?
2. Existem �reas espec�ficas do sistema que os usu�rios consideram dif�ceis de usar ou confusas?
3. H� algum feedback dos usu�rios sobre funcionalidades existentes que precisam ser melhoradas ou ajustadas?
4. Quais s�o os principais requisitos de neg�cios ou metas que devem ser alcan�adas com a adi��o desta nova funcionalidade?
5. Existem tend�ncias de mercado ou tecnol�gicas que devemos considerar ao planejar novas funcionalidades?
6. Como esta nova funcionalidades se alinha com a vis�o e a estrat�gia de longo prazo do produto?
7. H� alguma restri��o de tempo, or�amento ou recursos que devemos levar em considera��o ao planejar o desenvolvimento da nova funcionalidade?
8. Existem integra��es com outros sistemas ou servi�os que precisam ser consideradas ao desenvolver esta funcionalidade?
9. Quais � o conceito de pronto para esta funcionalidade?
10. Quais s�o as principais m�tricas ou indicadores-chave de desempenho que devemos monitorar para avaliar o desempenho ap�s a publica��o?
11. Existe alguma preocupa��o de seguran�a ou conformidade regulat�ria que devemos abordar ao implementar?
12. Precisamos envolver outras �reas de desenvolvimento, como por exemplo UX?
13. Quais s�o os casos de uso ou fluxos de trabalho espec�ficos que a funcionalidade deve suportar?
14. Quais s�o os requisitos de escalabilidade ou desempenho que devemos considerar ao desenvolver a funcionalidades?

## Formul�rio T�cnico

1. Quais classes ser�o alteradas e/ou adicionadas?
2. Qual os m�todos ser�o alteradas e/ou adicionadas?
3. Qual o projeto e a solu��o que ser�o modificados?
4. Qual a URL do ambiente de homologa��o?
5. Forne�a dois cen�rios de testes, com o exemplo de entrada e sa�da esperados.
7. Quais as URLs das ferramentas de observabilidade ser�o necess�rias para p�s produ��o?