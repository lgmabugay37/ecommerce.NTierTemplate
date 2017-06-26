using System.Linq;

namespace eCommerce.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void Remove(object id);
        void Update(TEntity entity);
        void SaveChanges();
        
    }
}