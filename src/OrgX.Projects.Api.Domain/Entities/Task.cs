using OrgX.Projects.Api.Domain.Core;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Task(
    Guid? id,
    string title,
    string detail,
    short status,
    short priority,
    DateTime? endDate,
    Guid? projectId,
    Project? project = null,
    IEnumerable<Comment> comments = null) 
    : Entity(id)
{
    public string Title => title;
    public Guid? ProjectId => projectId;
    public string Detail => detail;
    public short Status => status;
    public short Priority => priority;
    public DateTime? EndDate => endDate;
    public Project? Project { get; private set; } = project;
    public IEnumerable<Comment> Comments { get; private set; } = comments;

    public Task(
        Guid? id,
        string title,
        string detail,
        short status,
        short priority,
        DateTime? endDate,
        Guid? projectId)
        : this(
              id,
              title,
              detail,
              status,
              priority,
              endDate,
              projectId,
              null,
              null) {}
}
