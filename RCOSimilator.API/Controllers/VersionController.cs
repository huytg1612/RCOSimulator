using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCOSimilator.API.RCOAuthentication;
using RCOSimulator.Data.Globals;

namespace RCOSimilator.API.Controllers
{
    [Route("/api/version")]
    [ApiController]
    public class VersionController : BaseController
    {
        public VersionController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        [ApiKey]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
