namespace OrgX.Projects.Api.Application.AppModels;

public class TaskAppModel(
    Guid? id,
    string title,
    string detail,
    short status,
    short priority,
    DateTime? endDate,
    Guid? projectId,
    ProjectAppModel? project = null)
{
    public Guid? Id => id;
    public string Title => title;
    public string Detail => detail;
    public short Status => status;
    public short Priority => priority;
    public DateTime? EndDate => endDate;
    public Guid? ProjectId => projectId;
    public ProjectAppModel? Project => project;
}
