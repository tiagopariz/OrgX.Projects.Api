using Microsoft.Extensions.DependencyInjection;
using OrgX.Projects.Api.Domain.Interfaces.Repositories;
using OrgX.Projects.Api.Infra.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.Application.IoC;

[ExcludeFromCodeCoverage]
public static class AppServiceExtension
{
    public static IServiceCollection AddApplicationInfraServices(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IHistoryRepository, HistoryRepository>();

        return services;
    }
}
