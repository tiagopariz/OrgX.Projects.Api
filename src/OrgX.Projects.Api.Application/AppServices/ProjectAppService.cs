using AutoMapper;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;

namespace OrgX.Projects.Api.Application.AppServices;

public class ProjectAppService : IProjectAppService
{
    private readonly IProjectRepository _repository;
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public ProjectAppService(
        IProjectRepository repository,
        ITaskRepository taskRepository,
        IMapper mapper)
    {
        _repository = repository;
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public void Add(ProjectAppModel entity)
    {
        try
        {
            var itemToAdd = _mapper.Map<Project>(entity);
            _repository.Add(itemToAdd);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Remove(ProjectAppModel entity)
    {
        try
        {
            var openTasks = _taskRepository.GetAll(x => x.ProjectId == entity.Id && x.Status != 2)?.Any() ?? false;
            if (openTasks)
                throw new Exception("There are pending tasks, please close them all before deleting a project.");

            var itemToRemove = _mapper.Map<Project>(entity);
            _repository.Remove(itemToRemove);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Update(ProjectAppModel entity)
    {
        try
        {

            var itemToUpdate = _mapper.Map<Project>(entity);
            _repository.Update(itemToUpdate);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IEnumerable<ProjectAppModel> GetAll(Guid userId)
    {
        try
        {
            var entities = _repository.GetAll(x => x.UserId == userId)?.ToList();
            if (entities == null)
                return Enumerable.Empty<ProjectAppModel>();

            var results = _mapper.Map<IEnumerable<ProjectAppModel>>(entities);
            return results;
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public ProjectAppModel? GetById(Guid id)
    {
        try
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                return default;

            var result = _mapper.Map<ProjectAppModel>(entity);
            return result;
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}
