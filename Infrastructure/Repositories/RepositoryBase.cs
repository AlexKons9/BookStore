using Database;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : ΤEntity
    {
        private readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> GetAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<TEntity>() : _context.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _context.Set<TEntity>().Where(expression)
                                : _context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public void Create(TEntity entity) => _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity) =>  _context.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
    }
}
