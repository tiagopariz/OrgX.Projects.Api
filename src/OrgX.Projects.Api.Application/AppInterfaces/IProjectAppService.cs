using OrgX.Projects.Api.Application.AppModels;

namespace OrgX.Projects.Api.Application.AppInterfaces;

public interface IProjectAppService
{
    void Add(ProjectAppModel entity);
    void Remove(ProjectAppModel entity);
    void Update(ProjectAppModel entity);
    public IEnumerable<ProjectAppModel> GetAll(Guid userId);
    public ProjectAppModel GetById(Guid id);
}
