using Microsoft.EntityFrameworkCore;
using RCOSimulator.Data.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCOSimulator.Data.Repositories
{
    public interface IBaseRepository<K, E> where E : class
    {
        IQueryable<E> GetAll();
        E Get(K id);
        E Update(E entity);
        E Create(E entity);
        void SaveChanges();
        E Remove(E entity);
    }

    public abstract class BaseRepository<K, E> : IBaseRepository<K, E> where E : class
    {
        protected IUnitOfWork _uow { get; set; }
        DbContext _dbContext;
        protected DbSet<E> _set;
        private DbContext dbContext;

        public BaseRepository(IUnitOfWork uow, DbContext dbContext)
        {
            _uow = uow;
            _dbContext = dbContext;
            _set = _dbContext.Set<E>();
        }

        public E Create(E entity)
        {
            return _set.Add(entity).Entity;
        }

        public abstract E Get(K id);


        public IQueryable<E> GetAll()
        {
            return _set;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public E Update(E entity)
        {
            return _set.Update(entity).Entity;
        }

        public E Remove(E entity)
        {
            return _set.Remove(entity).Entity;
        }
    }
}
