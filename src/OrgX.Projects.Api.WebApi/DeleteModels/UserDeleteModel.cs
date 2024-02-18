using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.DeleteModels;

[ExcludeFromCodeCoverage]
public class UserDeleteModel(
    Guid id,
    string username,
    string role)
{
    public Guid Id => id;
    public string Username => username;
    public string Role => role;
}
