using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.WebApi.DeleteModels;
using OrgX.Projects.Api.WebApi.GetModels;
using OrgX.Projects.Api.WebApi.PostModels;
using OrgX.Projects.Api.WebApi.PutModels;
using OrgX.Tasks.Api.WebApi.GetModels;
using OrgX.Tasks.Api.WebApi.PostModels;
using OrgX.Tasks.Api.WebApi.PutModels;
using System.ComponentModel.DataAnnotations;

namespace OrgX.Projects.Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentAppService _appService;
        private readonly IMapper _mapper;

        public CommentsController(
            ICommentAppService appService,
            IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("", Order = 0)]
        public ActionResult<GetResponse<IEnumerable<CommentGetModel>>> Get([Required] Guid projectId)
        {
            var appResults = _appService.GetAll(projectId);
            var results = _mapper.Map<IEnumerable<CommentGetModel>>(appResults);
            return Ok(new GetResponse<IEnumerable<CommentGetModel>>(new GetMetadata(), results));
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("", Order = 1)]
        public ActionResult<PostResponse<CommentGetModel>> Post(
            CommentPostModel item)
        {
            try
            {
                var itemToAdd = _mapper.Map<CommentPostModel, CommentAppModel>(item);
                _appService.Add(itemToAdd);

                var result = _mapper.Map<CommentAppModel, CommentGetModel>(itemToAdd);
                return CreatedAtRoute("",
                                      new { id = result.Id },
                                      new PostResponse<CommentGetModel>(new PostMetadata(),
                                                                     result));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("", Order = 2)]
        public ActionResult<PutResponse<CommentPutModel>> Put(
            CommentPutModel item)
        {
            try
            {
                var itemToAdd = _mapper.Map<CommentPutModel, CommentAppModel>(item);
                _appService.Update(itemToAdd);

                var result = _mapper.Map<CommentAppModel, CommentPutModel>(itemToAdd);
                return CreatedAtRoute("",
                                      new { id = result.Id },
                                      new PutResponse<CommentPutModel>(new PutMetadata(),
                                                                    result));
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }

        [HttpDelete]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [Route("", Order = 3)]
        public ActionResult Delete(CommentDeleteModel item)
        {
            try
            {
                if (item == null)
                    return NotFound();

                var itemToDelete = _mapper.Map<CommentAppModel>(item);
                _appService.Remove(itemToDelete);

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }
        }
    }
}
