using OrgX.Projects.Api.Domain.Core;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Project(
    Guid? id,
    string title,
    Guid userId,
    User? user,
    IEnumerable<Task>? tasks = null)
    : Entity(id)
{
    public string Title => title;
    public Guid UserId => userId;
    public User? User { get; private set; } = user;
    public IEnumerable<Task>? Tasks => tasks;

    protected Project(
        Guid? id,
        string title,
        Guid userId) 
        : this(
              id,
              title,
              userId,
              null,
              null) { }
}
