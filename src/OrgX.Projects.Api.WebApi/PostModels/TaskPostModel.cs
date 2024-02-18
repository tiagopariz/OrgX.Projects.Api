using OrgX.Projects.Api.WebApi.Enums;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.PostModels;

[ExcludeFromCodeCoverage]
public class TaskPostModel(
    string title, 
    string detail,
    Status status,
    Priority priority,
    Guid? projectId)
{
    public Guid Id => Guid.NewGuid();
    public string Title => title;
    public string Detail => detail;
    public Status Status => status;
    public Priority Priority => priority;
    public Guid? ProjectId => projectId;
}
