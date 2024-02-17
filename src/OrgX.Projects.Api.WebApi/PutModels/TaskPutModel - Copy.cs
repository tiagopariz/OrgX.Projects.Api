namespace OrgX.Tasks.Api.WebApi.PutModels;

public class CommentPutModel(
    Guid id,
    string title,
    Guid taskId)
{
    public Guid Id => id;
    public string Title => title;
    public Guid TaskId => taskId;
}
