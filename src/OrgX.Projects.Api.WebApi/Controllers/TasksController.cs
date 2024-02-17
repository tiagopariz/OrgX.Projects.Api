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
    public class TasksController : ControllerBase
    {
        private readonly ITaskAppService _appService;
        private readonly IMapper _mapper;

        public TasksController(
            ITaskAppService appService,
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
        public ActionResult<GetResponse<IEnumerable<TaskGetModel>>> Get([Required] Guid projectId)
        {
            var appResults = _appService.GetAll(projectId);
            var results = _mapper.Map<IEnumerable<TaskGetModel>>(appResults);
            return Ok(new GetResponse<IEnumerable<TaskGetModel>>(new GetMetadata(), results));
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Route("Report", Order = 0)]
        public ActionResult<GetResponse<IEnumerable<object>>> Report()
        {
            var appResults = _appService.Report();
            return Ok(appResults);
        }

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(401)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("", Order = 1)]
        public ActionResult<PostResponse<TaskGetModel>> Post(
            TaskPostModel item)
        {
            try
            {
                var itemToAdd = _mapper.Map<TaskPostModel, TaskAppModel>(item);
                _appService.Add(itemToAdd);

                var result = _mapper.Map<TaskAppModel, TaskGetModel>(itemToAdd);
                return CreatedAtRoute("",
                                      new { id = result.Id },
                                      new PostResponse<TaskGetModel>(new PostMetadata(),
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
        public ActionResult<PutResponse<TaskPutModel>> Put(
            TaskPutModel item)
        {
            try
            {
                var itemToAdd = _mapper.Map<TaskPutModel, TaskAppModel>(item);
                _appService.Update(itemToAdd);

                var result = _mapper.Map<TaskAppModel, TaskPutModel>(itemToAdd);
                return CreatedAtRoute("",
                                      new { id = result.Id },
                                      new PutResponse<TaskPutModel>(new PutMetadata(),
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
        public ActionResult Delete(TaskDeleteModel item)
        {
            try
            {
                if (item == null)
                    return NotFound();

                var itemToDelete = _mapper.Map<TaskAppModel>(item);
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
