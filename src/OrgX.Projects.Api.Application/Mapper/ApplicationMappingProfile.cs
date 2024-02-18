using AutoMapper;
using OrgX.Projects.Api.Application.AppModels;
using System.Diagnostics.CodeAnalysis;
using Entities = OrgX.Projects.Api.Domain.Entities;

namespace OrgX.Projects.Api.Application.Mapper;

[ExcludeFromCodeCoverage]
public static class ApplicationMappingProfile
{
    public static void CreateApplicationMappingProfile(Profile profile)
    {
        profile.CreateMap<UserAppModel, Entities.User>().MaxDepth(1).ReverseMap().PreserveReferences();
        profile.CreateMap<ProjectAppModel, Entities.Project>().MaxDepth(1).ReverseMap().PreserveReferences();
        profile.CreateMap<TaskAppModel, Entities.Task>().MaxDepth(1).ReverseMap().PreserveReferences();
        profile.CreateMap<CommentAppModel, Entities.Comment>().MaxDepth(1).ReverseMap().PreserveReferences();
    }
}
