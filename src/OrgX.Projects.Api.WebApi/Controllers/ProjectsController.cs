using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.Application.AppModels;
using OrgX.Projects.Api.WebApi.DeleteModels;
using OrgX.Projects.Api.WebApi.GetModels;
using OrgX.Projects.Api.WebApi.PostModels;
using OrgX.Projects.Api.WebApi.PutModels;
using System.ComponentModel.DataAnnotations;

namespace OrgX.Projects.Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectAppService _appService;
        private readonly IMapper _mapper;

        public ProjectsController(
            IProjectAppService appService,
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
        public ActionResult<GetResponse<IEnumerable<ProjectGetModel>>> Get([Required] Guid userId)
        {
            var appResults = _appService.GetAll(userId);
            var results = _mapper.Map<IEnumerable<ProjectGetModel>>(appResults);
            return Ok(new GetResponse<IEnumerable<ProjectGetModel>>(new GetMetadata(), results));
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("", Order = 1)]
        public ActionResult<PostResponse<ProjectGetModel>> Post(
            ProjectPostModel item)
        {
            try
            {
                var itemToAdd = _mapper.Map<ProjectPostModel, ProjectAppModel>(item);
                _appService.Add(itemToAdd);

                var result = _mapper.Map<ProjectAppModel, ProjectGetModel>(itemToAdd);
                return CreatedAtRoute("",
                                      new { id = result.Id },
                                      new PostResponse<ProjectGetModel>(new PostMetadata(),
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
        public ActionResult<PutResponse<ProjectPutModel>> Put(
            ProjectPutModel item)
        {
            try
            {
                var itemToAdd = _mapper.Map<ProjectPutModel, ProjectAppModel>(item);
                _appService.Update(itemToAdd);

                var result = _mapper.Map<ProjectAppModel, ProjectPutModel>(itemToAdd);
                return CreatedAtRoute("",
                                      new { id = result.Id },
                                      new PutResponse<ProjectPutModel>(new PutMetadata(),
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
        public ActionResult Delete(ProjectDeleteModel item)
        {
            try
            {
                if (item == null)
                    return NotFound();

                var itemToDelete = _mapper.Map<ProjectAppModel>(item);
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
