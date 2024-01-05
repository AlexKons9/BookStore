using Domain.Abstractions;
using RepositoryInterfaces;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {

        public GenericRepository()
        {
            
        }


        public Task<IEnumerable<TEntity>> GetAll(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
        {
            throw new NotImplementedException();
        }
        public Task<TEntity> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
