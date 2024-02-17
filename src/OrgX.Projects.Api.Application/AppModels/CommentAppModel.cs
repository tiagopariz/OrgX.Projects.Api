namespace OrgX.Projects.Api.Application.AppModels;

public class CommentAppModel(
    Guid? id,
    string content,
    Guid taskId,
    TaskAppModel? task = null)
{
    public Guid? Id => id;
    public string Content => content;
    public Guid TaskId => taskId;
    public TaskAppModel? Task => task;
}
