using Domain.Abstractions;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : ΤEntity
    {
        IQueryable<TEntity> GetAll(bool trackChanges);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity,bool>> expression, bool trackChanges);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
