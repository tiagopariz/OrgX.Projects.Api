namespace OrgX.Projects.Api.WebApi.GetModels;

public class ProjectGetModel(
    Guid id,
    string title,
    Guid userId,
    IEnumerable<TaskGetModel>? tasks)
{
    public Guid Id => id;
    public string Title => title;
    public Guid UserId => userId;
    public IEnumerable<TaskGetModel>? Tasks => tasks;
}
