using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using MvcAjaxDemo.Data.Repositories.Abstract;
using MvcAjaxDemo.Data.Core.Domain;

namespace MvcAjaxDemo.Data.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected DbSet _currentDbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _currentDbSet = _context.Set<TEntity>();

        }
        public TEntity Get(int id)
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return CurrentDbSet.Cast<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.SingleOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return CurrentDbSet.Cast<TEntity>().ToList();

        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return CurrentDbSet.Cast<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return CurrentDbSet.Cast<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            CurrentDbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            CurrentDbSet.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            CurrentDbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            CurrentDbSet.RemoveRange(entities);
        }

        private DbSet CurrentDbSet
        {
            get { return _currentDbSet as DbSet; }
        }
    }
}
