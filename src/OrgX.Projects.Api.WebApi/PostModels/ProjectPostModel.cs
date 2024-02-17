namespace OrgX.Projects.Api.WebApi.PostModels;

public class ProjectPostModel(string title, Guid userId)
{
    public Guid Id => Guid.NewGuid();
    public string Title => title;
    public Guid UserId => userId;
}
