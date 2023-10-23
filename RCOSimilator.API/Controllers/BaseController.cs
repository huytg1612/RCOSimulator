using Microsoft.AspNetCore.Mvc;
using RCOSimulator.Data.Globals;

namespace RCOSimilator.API.Controllers
{
    public interface IBaseController
    {
        IUnitOfWork _uow { get; set; }
    }
    public class BaseController : ControllerBase, IBaseController
    {
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IUnitOfWork _uow { get; set; }
    }
}
