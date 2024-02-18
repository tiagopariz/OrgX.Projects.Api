using OrgX.Projects.Api.Application.AppServices;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.IoC;
using System.Diagnostics.CodeAnalysis;

namespace OrgX.Projects.Api.WebApi.IoC;

[ExcludeFromCodeCoverage]
public static class WepApiServiceExtension
{
    public static IServiceCollection AddWebApiApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IUserAppService, UserAppService>();
        services.AddTransient<ITaskAppService, TaskAppService>();
        services.AddTransient<IProjectAppService, ProjectAppService>();
        services.AddTransient<ICommentAppService, CommentAppService>();

        AppServiceExtension.AddApplicationInfraServices(services);

        return services;
    }    
}
