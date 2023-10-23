using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Repositories
{
    public interface IAccessGroupRepository : IBaseRepository<int, AccessGroup> 
    {
        AccessGroup CreateAccessGroup(AccessGroupCreateModel model);
    }
    public class AccessGroupRepository : BaseRepository<int, AccessGroup>, IAccessGroupRepository
    {
        public AccessGroupRepository(IUnitOfWork uow, DbContext dbContext) : base(uow, dbContext)
        {
        }

        public override AccessGroup Get(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);
        }

        public AccessGroup CreateAccessGroup(AccessGroupCreateModel model)
        {
            var mapper = _uow.GetMapper();
            var accesGroup = mapper.Map<AccessGroup>(model);
            return Create(accesGroup);
        }
    }
}
