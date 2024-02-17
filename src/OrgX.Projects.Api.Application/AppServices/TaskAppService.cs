using AutoMapper;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using Entities = OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using System.Collections;

namespace OrgX.Projects.Api.Application.AppServices;

public class TaskAppService : ITaskAppService
{
    private readonly ITaskRepository _repository;
    private readonly IMapper _mapper;

    public TaskAppService(
        ITaskRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Add(TaskAppModel entity)
    {
        try
        {
            var taskCount = _repository.GetAll(x => x.ProjectId == entity.ProjectId)?.Count() ?? 0;

            if (taskCount > 20)
                throw new Exception("Projects only allow a maximum of 20 tasks.");

            var itemToAdd = _mapper.Map<Entities.Task>(entity);
            _repository.Add(itemToAdd);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Remove(TaskAppModel entity)
    {
        try
        {
            var itemToRemove = _mapper.Map<Entities.Task>(entity);
            _repository.Remove(itemToRemove);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Update(TaskAppModel entity)
    {
        try
        {

            var itemToUpdate = _mapper.Map<Entities.Task>(entity);
            _repository.Update(itemToUpdate);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IEnumerable<TaskAppModel> GetAll(Guid projectId)
    {
        try
        {
            var entities = _repository.GetAll(x => x.ProjectId == projectId)?.ToList();
            if (entities == null)
                return Enumerable.Empty<TaskAppModel>();

            var results = _mapper.Map<IEnumerable<TaskAppModel>>(entities);
            return results;
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public TaskAppModel? GetById(Guid id)
    {
        try
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                return default;

            var result = _mapper.Map<TaskAppModel>(entity);
            return result;
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IEnumerable? Report()
    {
        try
        {
            var entities = _repository.GetAll(x => x.EndDate >= DateTime.Now.AddDays(-30))?
                                      .ToList()
                                      .GroupBy(x => x.Project.UserId)
                                      .Select(x => new
                                      {
                                          userId = x.Key,
                                          count = x.Count()
                                      });
            if (entities == null)
                return null;

            return entities;
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}

