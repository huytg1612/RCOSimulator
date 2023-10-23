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
    public interface IUserRepository : IBaseRepository<int, User> 
    {
        User CreateUser(UserCreateModel model);
        User UpdateUser(UserUpdateModel model);
    }
    public class UserRepository : BaseRepository<int, User>, IUserRepository
    {
        public UserRepository(IUnitOfWork uow, DbContext dbContext) : base(uow, dbContext)
        {
        }

        public User CreateUser(UserCreateModel model)
        {
            var mapper = _uow.GetMapper();
            var user = mapper.Map<User>(model);
            return Create(user);
        }

        public override User Get(int id)
        {
            return GetAll().SingleOrDefault(u => u.Id == id);
        }

        public User UpdateUser(UserUpdateModel model)
        {
            var mapper = _uow.GetMapper();
            var user = mapper.Map<User>(model);
            return Update(user);
        }
    }
}
