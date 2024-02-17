using OrgX.Projects.Api.Domain.Core;

namespace OrgX.Projects.Api.Domain.Entities;

public class Comment(
    Guid? id,
    Guid taskId,
    string content,
    Task? task = null)
    : Entity(id)
{
    public string Content => content;
    public Guid TaskId => taskId;
    public Task? Task { get; private set; } = task;

    protected Comment(
        Guid? id,
        Guid taskId,
        string content)
        : this(
              id,
              taskId,
              content,
              null) { }
}
