using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.GetModels;

[ExcludeFromCodeCoverage]
public class UserGetModel(
    Guid id,
    string username,
    string role)
{
    public Guid Id { get; } = id;
    public string Username { get; } = username;
    public string Role => role;
}
