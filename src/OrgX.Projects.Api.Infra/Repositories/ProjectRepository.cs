using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using System.Linq.Expressions;

namespace OrgX.Projects.Api.Infra.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DbSet<Project> _dbSet;
    private readonly IHistoryRepository _historyRepository;
    private readonly ProjectsDbContext _context;
    private const string UserId = "2bd26aa6-5344-4e51-b4b8-144bfb631f3f";

    public ProjectRepository(
        IConfiguration configuration,
        IHistoryRepository historyRepository)
    {
        _context = new ProjectsDbContext(configuration);
        _dbSet = _context.Set<Project>();
        _historyRepository = historyRepository;
    }

    public virtual void Add(Project entity)
    {
        try
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            SaveHistory(entity, "INSERT");
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public virtual void Remove(Project entity)
    {
        try
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            SaveHistory(entity, "DELETE");
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public virtual void Update(Project entity)
    {
        try
        {
            if (_context != null)
                _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            SaveHistory(entity, "UPDATE");
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    public IQueryable<Project>? GetAll(Expression<Func<Project, bool>>? expression = null)
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

    public Project? GetById(Guid id)
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

    private void SaveHistory(Project entity, string operation)
    {
        if (entity == null || entity.Id == Guid.Empty || entity.Id == null)
            return;

        if (operation == "INSERT")
            _historyRepository.NewHistory(
                entity.GetType().Name,
                "Id",
                operation,
                (Guid)entity.Id,
                entity.Id.ToString(),
                Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "Title",
            operation,
            (Guid)entity.Id,
            entity.Title,
            Guid.Parse(UserId));

        _historyRepository.NewHistory(
            entity.GetType().Name,
            "UserId",
            operation,
            (Guid)entity.Id,
            entity.UserId.ToString(),
            Guid.Parse(UserId));
    }
}
