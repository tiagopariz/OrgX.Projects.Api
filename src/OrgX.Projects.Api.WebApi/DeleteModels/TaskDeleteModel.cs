using OrgX.Projects.Api.WebApi.Enums;

namespace OrgX.Projects.Api.WebApi.DeleteModels;

public class TaskDeleteModel(
    Guid id,
    string title,
    string detail,
    Status status,
    Priority priority,
    DateTime? endDate,
    Guid? projectId)
{
    public Guid Id => id;
    public string Title => title;
    public string Detail => detail;
    public Status Status => status;
    public Priority Priority => priority;
    public DateTime? EndDate => endDate;
    public Guid? ProjectId => projectId;
}
