using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Globals
{
    public interface IUnitOfWork
    {
        IServiceProvider _provider { get; set; }
        T GetService<T>();
        IMapper GetMapper();
        void SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        DbContext _dbContext;
        public UnitOfWork(IServiceProvider provider) 
        {
            _provider = provider;
            _dbContext = provider.GetService<DbContext>();
        }

        public IServiceProvider _provider { get; set; }

        public T GetService<T>()
        {
            return _provider.GetService<T>();
        }

        public IMapper GetMapper()
        {
            var profile = _provider.GetService<MappingProfile>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return config.CreateMapper();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
