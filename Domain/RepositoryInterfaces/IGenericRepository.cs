using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
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
