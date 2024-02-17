using OrgX.Projects.Api.Application.AppServices;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.IoC;

namespace OrgX.Projects.Api.WebApi.IoC;

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
