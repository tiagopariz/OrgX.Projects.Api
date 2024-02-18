using OrgX.Projects.Api.Domain.Core;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Domain.Entities;

[ExcludeFromCodeCoverage]
public class User(
    Guid? id,
    string username,
    string role,
    IEnumerable<Project>? projects = null,
    IEnumerable<History>? histories = null)
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
