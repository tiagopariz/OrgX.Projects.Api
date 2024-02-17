using AutoMapper;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;

namespace OrgX.Projects.Api.Application.AppServices;

public class CommentAppService : ICommentAppService
{
    private readonly ICommentRepository _repository;
    private readonly IMapper _mapper;

    public CommentAppService(
        ICommentRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public void Add(CommentAppModel entity)
    {
        try
        {
            var itemToAdd = _mapper.Map<Comment>(entity);
            _repository.Add(itemToAdd);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Remove(CommentAppModel entity)
    {
        try
        {
            var itemToRemove = _mapper.Map<Comment>(entity);
            _repository.Remove(itemToRemove);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Update(CommentAppModel entity)
    {
        try
        {

            var itemToUpdate = _mapper.Map<Comment>(entity);
            _repository.Update(itemToUpdate);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IEnumerable<CommentAppModel> GetAll(Guid taskId)
    {
        try
        {
            var entities = _repository.GetAll(x => x.TaskId == taskId)?.ToList();
            if (entities == null)
                return Enumerable.Empty<CommentAppModel>();

            var results = _mapper.Map<IEnumerable<CommentAppModel>>(entities);
            return results;
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public CommentAppModel? GetById(Guid id)
    {
        try
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                return default;

            var result = _mapper.Map<CommentAppModel>(entity);
            return result;
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}

