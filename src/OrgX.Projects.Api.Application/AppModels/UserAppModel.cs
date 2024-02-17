namespace OrgX.Projects.Api.Application.AppModels;

public class UserAppModel(
    Guid? id,
    string username,
    string role)
{
    public Guid? Id => id;
    public string Username => username;
    public string Role => role;
}
