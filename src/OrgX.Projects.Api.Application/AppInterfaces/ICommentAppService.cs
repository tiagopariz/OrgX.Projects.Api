using OrgX.Projects.Api.Application.AppModels;

namespace OrgX.Projects.Api.Application.AppInterfaces;


public interface ICommentAppService
{
    void Add(CommentAppModel entity);
    void Remove(CommentAppModel entity);
    void Update(CommentAppModel entity);
    public IEnumerable<CommentAppModel> GetAll(Guid projectId);
    public CommentAppModel GetById(Guid id);
}
