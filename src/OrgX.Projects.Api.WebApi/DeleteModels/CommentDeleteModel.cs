namespace OrgX.Projects.Api.WebApi.DeleteModels;

public class CommentDeleteModel(
    Guid id,
    string content,
    Guid taskId)
{
    public Guid Id => id;
    public string Content => content;
    public Guid TaskId => taskId;
}
