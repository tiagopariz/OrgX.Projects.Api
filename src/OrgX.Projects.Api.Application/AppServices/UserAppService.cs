using AutoMapper;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;

namespace OrgX.Projects.Api.Application.AppServices;

public class UserAppService : IUserAppService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserAppService(
        IUserRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<UserAppModel> GetAll()
    {
        try
        {
            var entities = _repository.GetAll()?.ToList();
            if (entities == null)
                return Enumerable.Empty<UserAppModel>();

            var results = _mapper.Map<IEnumerable<UserAppModel>>(entities);
            return results;
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public UserAppModel? GetById(Guid id)
    {
        try
        {
            var entity = _repository.GetById(id);
            if (entity == null)
                return default;

            var result = _mapper.Map<UserAppModel>(entity);
            return result;
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}

