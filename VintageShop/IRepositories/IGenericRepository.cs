using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VintageShop.Models;

namespace VintageShop.IRepositories
{
    public interface IGenericRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Add(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();

 
        List<TEntity> GetAllActive();

        bool SaveCh();
    }
}
