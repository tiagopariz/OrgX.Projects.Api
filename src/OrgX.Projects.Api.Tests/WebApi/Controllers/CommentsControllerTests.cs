using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.WebApi.Controllers;
using OrgX.Projects.Api.WebApi.DeleteModels;
using OrgX.Projects.Api.WebApi.GetModels;
using OrgX.Projects.Api.WebApi.PostModels;
using OrgX.Tasks.Api.WebApi.GetModels;
using OrgX.Tasks.Api.WebApi.PostModels;

namespace OrgX.Projects.Api.Tests.WebApi.Controllers;

public class CommentsControllerTests
{
    [Fact]
    public void Get_WhenCalled_ReturnsOkResultWithComments()
    {
        // Arrange
        var mockCommentAppService = new Mock<ICommentAppService>();
        var mockMapper = new Mock<IMapper>();

        var projectId = Guid.NewGuid();
        var comments = new List<CommentAppModel>
            {
                new CommentAppModel(Guid.NewGuid(), "Comment1", Guid.NewGuid()),
                new CommentAppModel(Guid.NewGuid(), "Comment2", Guid.NewGuid())
            };
        mockCommentAppService.Setup(service => service.GetAll(projectId)).Returns(comments);

        var expectedResponse = new GetResponse<IEnumerable<CommentGetModel>>(
            new GetMetadata(),
            new List<CommentGetModel>
            {
                    new CommentGetModel((Guid)comments[0].Id, comments[0].Content, comments[0].TaskId),
                    new CommentGetModel((Guid)comments[1].Id, comments[1].Content, comments[1].TaskId)
            });
        mockMapper.Setup(mapper => mapper.Map<IEnumerable<CommentGetModel>>(comments)).Returns(expectedResponse.Results);

        var controller = new CommentsController(mockCommentAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Get(projectId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<GetResponse<IEnumerable<CommentGetModel>>>(okResult.Value);
        Assert.Equal(expectedResponse.Results, response.Results);
    }

    [Fact]
    public void Post_WhenCalledWithValidModel_ReturnsCreatedAtRouteResult()
    {
        // Arrange
        var mockCommentAppService = new Mock<ICommentAppService>();
        var mockMapper = new Mock<IMapper>();

        var commentPostModel = new CommentPostModel("Test Comment", Guid.NewGuid());
        var commentAppModel = new CommentAppModel((Guid)commentPostModel.Id, commentPostModel.Content, commentPostModel.TaskId);
        var commentGetModel = new CommentGetModel((Guid)commentAppModel.Id, commentAppModel.Content, commentAppModel.TaskId);

        mockMapper.Setup(mapper => mapper.Map<CommentPostModel, CommentAppModel>(commentPostModel)).Returns(commentAppModel);
        mockMapper.Setup(mapper => mapper.Map<CommentAppModel, CommentGetModel>(commentAppModel)).Returns(commentGetModel);

        var controller = new CommentsController(mockCommentAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Post(commentPostModel);

        // Assert
        var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
        var postResponse = Assert.IsType<PostResponse<CommentGetModel>>(createdAtRouteResult.Value);
        Assert.Equal(commentGetModel, postResponse.Results);
    }

    [Fact]
    public void Delete_WhenCalledWithValidModel_ReturnsNoContentResult()
    {
        // Arrange
        var mockCommentAppService = new Mock<ICommentAppService>();
        var mockMapper = new Mock<IMapper>();

        var commentDeleteModel = new CommentDeleteModel(Guid.NewGuid(), "Test Content", Guid.NewGuid());

        var controller = new CommentsController(mockCommentAppService.Object, mockMapper.Object);

        // Act
        var result = controller.Delete(commentDeleteModel);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
