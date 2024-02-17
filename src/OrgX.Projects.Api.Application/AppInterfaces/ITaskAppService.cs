using OrgX.Projects.Api.Application.AppModels;
using System.Collections;

namespace OrgX.Projects.Api.Application.AppInterfaces;

public interface ITaskAppService
{
    void Add(TaskAppModel entity);
    void Remove(TaskAppModel entity);
    void Update(TaskAppModel entity);
    IEnumerable<TaskAppModel> GetAll(Guid projectId);
    TaskAppModel GetById(Guid id);
    IEnumerable? Report();
}
