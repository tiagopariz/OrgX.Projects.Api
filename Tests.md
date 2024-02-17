# Testes exploratórios

## Docs

https://localhost:32770/swagger/index.html

## API

1. Listagem de Projetos

GET URL: https://localhost:32770/Projects?userId=2bd26aa6-5344-4e51-b4b8-144bfb631f3f
Result: 

```json
{
  "metadata": {},
  "results": [
    {
      "id": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d",
      "title": "Project 1",
      "userId": "2bd26aa6-5344-4e51-b4b8-144bfb631f3f",
      "tasks": []
    }
  ]
}
```

2. Visualização de Tarefas

GET URL: https://localhost:32770/Tasks?projectId=beb32c8b-5e44-4f7e-abc3-05d3a7823b9d

Results: 

```json
{
  "metadata": {},
  "results": [
    {
      "id": "66e7562d-3719-4da6-bdcb-95c2e38c80a1",
      "title": "Task 1 - Project 1",
      "detail": "Task 1 of Project 1",
      "status": 0,
      "priority": 0,
      "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d",
      "project": null
    }
  ]
}
```

3. Criação de Projetos

POST URL: https://localhost:32770/Projects

Request body:

```json
{
  "title": "Project 2",
  "userId": "2bd26aa6-5344-4e51-b4b8-144bfb631f3f"
}
```

Response body:

```json
{
  "metadata": {},
  "results": {
    "id": "46366b27-5658-4dfa-8230-274b12eb253a",
    "title": "Project 2",
    "userId": "2bd26aa6-5344-4e51-b4b8-144bfb631f3f",
    "tasks": []
  }
}
```

4. Criação de Tarefas

POST URL: https://localhost:32770/Tasks

Request body:

```json
{
  "title": "Tarefa 2 - Projeto 1",
  "detail": "Tarefa 2 do Projeto 1",
  "status": 0,
  "priority": 0,
  "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"
}
```

Response body:

```json
{
  "metadata": {},
  "results": {
    "id": "ed544e2d-dac8-4558-9a0f-62e667b85d14",
    "title": "Tarefa 2 - Projeto 1",
    "detail": "Tarefa 2 do Projeto 1",
    "status": 0,
    "priority": 0,
    "endDate": null,
    "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d",
    "project": null
  }
}
```

5. Atualização de tarefas

PUT URL: https://localhost:32770/Tasks

Request body:

```json
{
  "id": "66e7562d-3719-4da6-bdcb-95c2e38c80a1",
  "title": "Task 2 - Project 1",
  "detail": "Task 2 of Project 1",
  "status": 1,
  "endDate": null,
  "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"
}
```

Response body:

```json
{
  "metadata": {},
  "results": {
    "id": "66e7562d-3719-4da6-bdcb-95c2e38c80a1",
    "title": "Task 2 - Project 1",
    "detail": "Task 2 of Project 1",
    "status": 1,
    "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"
  }
}
```

6. Remoção de Tarefas

DELETE URL: https://localhost:32770/Tasks

Request body:

```json
{
    "id": "ed544e2d-dac8-4558-9a0f-62e667b85d14",
    "title": "Tarefa 1 - Projeto 2",
    "detail": "Tarefa 1 do Projeto 2",
    "status": 0,
    "priority": 0,
    "endDate": null,
    "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"
}
```

Response body:

```json
{
  "metadata": {},
  "results": {
    "id": "66e7562d-3719-4da6-bdcb-95c2e38c80a1",
    "title": "Task 2 - Project 1",
    "detail": "Task 2 of Project 1",
    "status": 1,
    "projectId": "beb32c8b-5e44-4f7e-abc3-05d3a7823b9d"
  }
}
```