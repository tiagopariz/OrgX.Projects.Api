namespace OrgX.Projects.Api.Application.AppModels;

public class ProjectAppModel(
    Guid? id,
    string title,
    Guid userId,
    IEnumerable<TaskAppModel>? tasks = null)
{
    public Guid? Id => id;
    public string Title => title;
    public Guid UserId => userId;
    public IEnumerable<TaskAppModel>? Tasks => tasks;
}
