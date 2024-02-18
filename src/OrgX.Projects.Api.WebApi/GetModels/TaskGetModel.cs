using OrgX.Projects.Api.WebApi.Enums;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.GetModels;

[ExcludeFromCodeCoverage]
public class TaskGetModel(
    Guid id,
    string title,
    string detail,
    Status status,
    Priority priority,
    DateTime? endDate,
    Guid? projectId = null,
    ProjectGetModel? project = null)
{
    public Guid Id => id;
    public string Title => title;
    public string Detail => detail;
    public Status Status => status;
    public Priority Priority => priority;
    public DateTime? EndDate => endDate;
    public Guid? ProjectId => projectId;
    public ProjectGetModel? Project => project;
}
