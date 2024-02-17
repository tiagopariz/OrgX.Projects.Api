﻿using OrgX.Projects.Api.WebApi.Enums;

namespace OrgX.Projects.Api.WebApi.PutModels;

public class TaskPutModel(
    Guid id,
    string title,
    string detail,
    Status status,
    Guid? projectId)
{
    public Guid Id => id;
    public string Title => title;
    public string Detail => detail;
    public Status Status => status;
    public Guid? ProjectId => projectId;
}
