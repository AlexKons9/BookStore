using Domain.Abstractions;
using System.Linq.Expressions;

namespace RepositoryInterfaces
{
    public interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll(bool trackChanges);
        Task<TEntity> GetByCondition(Expression<Func<TEntity,bool>> expression, bool trackChanges);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}
