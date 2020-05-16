using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTestPresentation.Repository
{
    public interface IRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> All<TEntity>() where TEntity : class;
        TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }

    public class Repository : IRepository
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}