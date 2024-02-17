using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DbSet<User> _dbSet;
    private readonly ProjectsDbContext _context;

    public UserRepository(
        IConfiguration configuration,
        IHistoryRepository historyRepository)
    {
        _context = new ProjectsDbContext(configuration);
        _dbSet = _context.Set<User>();
    }

    public IQueryable<User>? GetAll(Expression<Func<User, bool>>? expression = null)
    {
        try
        {
            return expression == null ? _dbSet.AsQueryable() : _dbSet.Where(expression);
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public User? GetById(Guid id)
    {
        try
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}
