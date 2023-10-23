using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCOSimilator.API.RCOAuthentication;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Services;
using RCOSimulator.Data.ViewModels;

namespace RCOSimilator.API.Controllers
{
    [Route("/api/accessgroup")]
    [ApiController]
    public class AccessGroupController : BaseController
    {
        AccessGroupService _service { get; set; }

        public AccessGroupController(IUnitOfWork uow) : base(uow)
        {
            _service = _uow.GetService<AccessGroupService>();
        }

        [HttpPost]
        [ApiKey]
        public IActionResult Create(AccessGroupCreateModel model)
        {
            try
            {
                var entity = _service.Create(model);
                return Ok(entity);
            }catch(Exception ex) 
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [ApiKey]
        public IActionResult Get([FromQuery]QueryParameters parameters)
        {
            var service = _uow.GetService<AccessGroupService>();
            var data = service.Get(parameters);
            return Ok(new ListAccessGroupModel
            {
                AccessGroups = data
            });
        }
    }
}
