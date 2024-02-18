using OrgX.Projects.Api.WebApi.Enums;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.PutModels;

[ExcludeFromCodeCoverage]
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
