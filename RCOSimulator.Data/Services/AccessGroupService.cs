using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Repositories;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Services
{
    public class AccessGroupService : BaseService
    {
        IAccessGroupRepository _repo { get; set; }

        public AccessGroupService(IUnitOfWork uow) : base(uow)
        {
            _repo = _uow.GetService<IAccessGroupRepository>();
        }

        public AccessGroupModel Create(AccessGroupCreateModel model)
        {
            if (_repo.GetAll().FirstOrDefault(a => a.Name.Equals(model.Name)) != null)
                throw new Exception($"Access group {model.Name} is already existed");
            var entity = _repo.CreateAccessGroup(model);
            if (entity == null)
                throw new Exception("Can not create access group");

            _uow.SaveChanges();
            var mapper = _uow.GetMapper();
            return mapper.Map<AccessGroupModel>(entity);
        }

        public List<AccessGroupModel> Get()
        {
            var accessGroups = _repo.GetAll();
            var mapper = _uow.GetMapper();
            return accessGroups.Select(a => mapper.Map<AccessGroupModel>(a)).ToList();
        }
    }
}
