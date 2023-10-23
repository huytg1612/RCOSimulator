using Microsoft.EntityFrameworkCore;
using RCOSimulator.Data.Extensions;
using RCOSimulator.Data.Globals;
using RCOSimulator.Data.Models;
using RCOSimulator.Data.Repositories;
using RCOSimulator.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Services
{
    public class UserService : BaseService
    {
        IUserRepository _repo;
        public UserService(IUnitOfWork uow) : base(uow)
        {
            _repo = _uow.GetService<IUserRepository>();
        }

        public UserModel Create(UserCreateModel model)
        {
            var entity = _repo.CreateUser(model);
            var mapper = _uow.GetMapper();
            _uow.SaveChanges();
            return mapper.Map<UserModel>(entity);
        }

        public UserModel Update(UserUpdateModel model)
        {            
            var entity = _repo.UpdateUser(model);
            var mapper = _uow.GetMapper();
            _uow.SaveChanges();
            return mapper.Map<UserModel>(entity);
        }

        public List<UserModel> Get(QueryParameters parameter)
        {
            var users = _repo.GetAll().Pagination<User>(parameter.Offset, parameter.Limit);
            var mapper = _uow.GetMapper();
            return users.Select(u => mapper.Map<UserModel>(u)).ToList();
        }

        public UserModel GetById(int id, bool isTracking = true)
        {
            var users = _repo.GetAll();
            if (!isTracking)
                users = users.AsNoTrackingWithIdentityResolution();
            var user = users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return null;

            var mapper = _uow.GetMapper();
            return mapper.Map<UserModel>(user);
        }

        public void Remove(UserModel model)
        {
            var mapper = _uow.GetMapper();
            var user = mapper.Map<User>(model);
            var entity = _repo.Remove(user);
            if (entity == null)
                throw new Exception("Remove user failed");

            _uow.SaveChanges();
        }
    }
}
