namespace OrgX.Projects.Api.Application.AppModels;

public class ProjectAppModel(
    Guid? id,
    string title,
    Guid userId,
    UserAppModel? user = null,
    IEnumerable<TaskAppModel>? tasks = null)
{
    public Guid? Id => id;
    public string Title => title;
    public Guid UserId => userId;
    public UserAppModel? User { get; private set; } = user;
    public IEnumerable<TaskAppModel>? Tasks => tasks;
}
