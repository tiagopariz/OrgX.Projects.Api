namespace OrgX.Tasks.Api.WebApi.PostModels;

public class CommentPostModel(
    string content, 
    Guid taskId)
{
    public Guid Id => Guid.NewGuid();
    public string Content => content;
    public Guid TaskId => taskId;
}
