using OrgX.Projects.Api.WebApi.GetModels;

namespace OrgX.Tasks.Api.WebApi.GetModels;

public class CommentGetModel(
    Guid id,
    string content,
    Guid taskId,
    TaskGetModel? task = null)
{
    public Guid Id => id;
    public string Content => content;
    public Guid TaskId => taskId;
    public TaskGetModel? Task => task;
}
