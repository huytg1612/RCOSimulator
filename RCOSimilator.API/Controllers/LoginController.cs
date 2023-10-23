using Microsoft.AspNetCore.Mvc;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.Services;
using RCOSimulator.Data.ViewModels;

namespace RCOSimilator.API.Controllers
{
    [Route("/api/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var service = _uow.GetService<LoginService>();
            var data = service.Login(model);
            return Ok(data);
        }
    }
}
