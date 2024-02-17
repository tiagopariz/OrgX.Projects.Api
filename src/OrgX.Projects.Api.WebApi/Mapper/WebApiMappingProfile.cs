using AutoMapper;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.Application.Mapper;
using OrgX.Projects.Api.WebApi.DeleteModels;
using OrgX.Projects.Api.WebApi.GetModels;
using OrgX.Projects.Api.WebApi.PostModels;
using OrgX.Projects.Api.WebApi.PutModels;
using OrgX.Tasks.Api.WebApi.GetModels;
using OrgX.Tasks.Api.WebApi.PostModels;
using OrgX.Tasks.Api.WebApi.PutModels;

namespace OrgX.Projects.Api.WebApi.Mapper;

public class WebApiMappingProfile : Profile
{
    public WebApiMappingProfile()
    {
        CreateMap<UserGetModel, UserAppModel>().MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<UserPostModel, UserAppModel>().MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<UserPutModel, UserAppModel>().MaxDepth(1).ReverseMap().PreserveReferences();

        CreateMap<TaskGetModel, TaskAppModel>()
            .ConstructUsing((getModel, context) =>
            new TaskAppModel(
                getModel.Id,
                title: getModel.Title,
                detail: getModel.Detail,
                status: (short)getModel.Status,
                priority: (short)getModel.Priority,
                endDate: getModel.EndDate,
                projectId: getModel.ProjectId))
            .MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<TaskPostModel, TaskAppModel>()
            .ConstructUsing((postModel, context) =>
            new TaskAppModel(
                postModel.Id, 
                title: postModel.Title,
                detail: postModel.Detail, 
                status: (short)postModel.Status,
                priority: (short)postModel.Priority,
                endDate: null,
                projectId: postModel.ProjectId))
            .MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<TaskPutModel, TaskAppModel>()
            .ConstructUsing((postModel, context) =>
            new TaskAppModel(
                postModel.Id,
                title: postModel.Title,
                detail: postModel.Detail,
                status: (short)postModel.Status,
                priority: 0,
                endDate: null,
                projectId: postModel.ProjectId))
            .MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<TaskDeleteModel, TaskAppModel>()
            .ConstructUsing((deleteModel, context) =>
            new TaskAppModel(
                id: deleteModel.Id,
                title: deleteModel.Title,
                detail: deleteModel.Detail,
                status: (short)deleteModel.Status,
                priority: (short)deleteModel.Priority,
                endDate: deleteModel.EndDate,
                projectId: deleteModel.ProjectId))
            .MaxDepth(1).ReverseMap().PreserveReferences();

        CreateMap<ProjectGetModel, ProjectAppModel>().MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<ProjectPostModel, ProjectAppModel>()
            .ConstructUsing((postModel, context) =>
            new ProjectAppModel(
                postModel.Id,
                title: postModel.Title,
                userId: postModel.UserId))
            .MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<ProjectPutModel, ProjectAppModel>().MaxDepth(1).ReverseMap().PreserveReferences();

        CreateMap<CommentGetModel, CommentAppModel>()
            .ConstructUsing((getModel, context) =>
            new CommentAppModel(
                getModel.Id,
                content: getModel.Content,
                taskId: getModel.TaskId))
            .MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<CommentPostModel, CommentAppModel>()
            .ConstructUsing((postModel, context) =>
            new CommentAppModel(
                postModel.Id,
                content: postModel.Content,
                taskId: postModel.TaskId))
            .MaxDepth(1).ReverseMap().PreserveReferences();
        CreateMap<CommentPutModel, CommentAppModel>().MaxDepth(1).ReverseMap().PreserveReferences();

        ApplicationMappingProfile.CreateApplicationMappingProfile(this);
    }
}
