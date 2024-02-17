using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrgX.Projects.Api.Application.AppInterfaces;
using OrgX.Projects.Api.WebApi.GetModels;

namespace OrgX.Projects.Api.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _appService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserAppService appService,
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
        public ActionResult<GetResponse<IEnumerable<UserGetModel>>> Get()
        {
            var appResults = _appService.GetAll();
            var results = _mapper.Map<IEnumerable<UserGetModel>>(appResults);
            return Ok(new GetResponse<IEnumerable<UserGetModel>>(new GetMetadata(), results));
        }

    }
}
