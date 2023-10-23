using RCOSimulator.Data.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Services
{
    public interface IBaseService
    {
        IUnitOfWork _uow { get; set; }
    }
    public class BaseService : IBaseService
    {
        public IUnitOfWork _uow { get; set; }
        public BaseService(IUnitOfWork uow) 
        {
            _uow = uow;
        }
    }
}
