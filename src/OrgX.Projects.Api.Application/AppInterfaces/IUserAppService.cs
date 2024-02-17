using OrgX.Projects.Api.Application.AppModels;

namespace OrgX.Projects.Api.Application.AppInterfaces;

public interface IUserAppService
{
    public IEnumerable<UserAppModel> GetAll();
    public UserAppModel GetById(Guid id);
}
