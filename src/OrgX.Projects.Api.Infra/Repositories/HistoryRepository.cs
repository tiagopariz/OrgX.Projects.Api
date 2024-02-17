using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Infra.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly DbSet<History> _dbSet;
    private readonly ProjectsDbContext _context;

    public HistoryRepository(IConfiguration configuration)
    {
        _context = new ProjectsDbContext(configuration);
        _dbSet = _context.Set<History>();
    }

    public void Add(History entity)
    {
        try
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Remove(History entity)
    {
        try
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public void Update(History entity)
    {
        try
        {
            if (_context != null)
                _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IQueryable<History>? GetAll(Expression<Func<History, bool>>? expression = null)
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

    public History? GetById(Guid id)
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

    public void NewHistory(
        string entity,
        string field,
        string operation,
        Guid primaryKeyId,
        string? newValue,
        Guid userId)
    {
        var newHistory = new History(
            Guid.NewGuid(),
            entity,
            field,
            primaryKeyId,
            operation,
            newValue,
            userId,
            DateTime.Now);
        
        Add(newHistory);
    }
}
