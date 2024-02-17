using OrgX.Projects.Api.Domain.Core;

namespace OrgX.Projects.Api.Domain.Entities;

public class User(
    Guid? id,
    string username,
    string role,
    IEnumerable<Project>? projects,
    IEnumerable<History>? histories)
    : Entity(id)
{
    public string Username => username;
    public string Role => role;
    public IEnumerable<Project>? Projects => projects;
    public IEnumerable<History>? Histories => histories;

    protected User(
        Guid? id,
        string username,
        string role)
        : this(
              id,
              username,
              role,
              null,
              null) { }
}
