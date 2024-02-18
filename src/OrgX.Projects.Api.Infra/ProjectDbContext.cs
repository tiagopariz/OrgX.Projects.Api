using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrgX.Projects.Api.Domain.Entities;
using OrgX.Projects.Api.Infra.EntityConfigurations;
using OrgX.Projects.Api.Infra.Seeds;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Infra;

[ExcludeFromCodeCoverage]
public class ProjectsDbContext : DbContext
{
    public virtual DbSet<User> User { get; set; } = null!;
    public virtual DbSet<Project> Project { get; set; } = null!;
    public virtual DbSet<Domain.Entities.Task> Tasks { get; set; } = null!;
    public virtual DbSet<History> Histories { get; set; } = null!;
    public virtual DbSet<Comment> Comment { get; set; } = null!;

    protected readonly IConfiguration Configuration;
    private readonly string? _connectionString;
    protected readonly IConfigurationRoot? _configurationFile;

    public ProjectsDbContext(IConfiguration configuration)
    {
        try
        {
            Configuration = configuration;

            var environmentPath = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var environmentAppSettings = environmentPath == null ? "" : ".Development";

            _configurationFile = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings{environmentAppSettings}.json")
                .Build();

            _connectionString = _configurationFile?
                                    .GetConnectionString("ProjectsSqlConnectionString");

        }
        catch (Exception exception)
        {
            throw;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Ocorreu um erro ao configurar o contexto: {exception.Message}");
            throw;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            // General conventions and settings
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.DeleteCascadeBehaviorToRestrict();
            modelBuilder.SetVarchar();
            modelBuilder.SetMaxLength();
            modelBuilder.SetPrimaryKey();

            // Mappings
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryEntityConfiguration());

            // Seeds
            modelBuilder.UserSeed();
            modelBuilder.ProjectSeed();
            modelBuilder.TaskSeed();
            modelBuilder.CommentSeed();
            modelBuilder.HistorySeed();

        }
        catch (Exception exception)
        {
            throw;
        }
    }
}
