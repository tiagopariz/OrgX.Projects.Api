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

# Refinamento


## Perguntas para refinamento de novas funcionalidades

1. Quais são as principais necessidades dos usuários que não estão sendo atendidas atualmente?
2. Existem áreas específicas do sistema que os usuários consideram difíceis de usar ou confusas?
3. Há algum feedback dos usuários sobre funcionalidades existentes que precisam ser melhoradas ou ajustadas?
4. Quais são os principais requisitos de negócios ou metas que devem ser alcançadas com a adição desta nova funcionalidade?
5. Existem tendências de mercado ou tecnológicas que devemos considerar ao planejar novas funcionalidades?
6. Como esta nova funcionalidades se alinha com a visão e a estratégia de longo prazo do produto?
7. Há alguma restrição de tempo, orçamento ou recursos que devemos levar em consideração ao planejar o desenvolvimento da nova funcionalidade?
8. Existem integrações com outros sistemas ou serviços que precisam ser consideradas ao desenvolver esta funcionalidade?
9. Quais é o conceito de pronto para esta funcionalidade?
10. Quais são as principais métricas ou indicadores-chave de desempenho que devemos monitorar para avaliar o desempenho após a publicação?
11. Existe alguma preocupação de segurança ou conformidade regulatória que devemos abordar ao implementar?
12. Precisamos envolver outras áreas de desenvolvimento, como por exemplo UX?
13. Quais são os casos de uso ou fluxos de trabalho específicos que a funcionalidade deve suportar?
14. Quais são os requisitos de escalabilidade ou desempenho que devemos considerar ao desenvolver a funcionalidades?

## Formulário Técnico

1. Quais classes serão alteradas e/ou adicionadas?
2. Qual os métodos serão alteradas e/ou adicionadas?
3. Qual o projeto e a solução que serão modificados?
4. Qual a URL do ambiente de homologação?
5. Forneça dois cenários de testes, com o exemplo de entrada e saída esperados.
7. Quais as URLs das ferramentas de observabilidade serão necessárias para pós produção?