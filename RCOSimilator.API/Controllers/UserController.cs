using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RCOSimilator.API.RCOAuthentication;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Services;
using RCOSimulator.Data.ViewModels;

namespace RCOSimilator.API.Controllers
{
    [Route("/api/user")]
    [ApiController]
    public class UserController : BaseController
    {
        UserService _service;
        public UserController(IUnitOfWork uow) : base(uow)
        {
            _service = _uow.GetService<UserService>();
        }

        [HttpGet]
        [ApiKey]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpPatch]
        public IActionResult Update(UserUpdateModel model)
        {
            try
            {
                if (_service.GetById(model.Id, false) == null)
                    return NotFound("User not found");
                var entity = _service.Update(model);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [ApiKey]
        public IActionResult Create(UserCreateModel model) 
        {
            try
            {
                var entity = _service.Create(model);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ApiKey]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _service.GetById(id, false);
                if (user == null)
                    return NotFound("User not found");
                _service.Remove(user);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
