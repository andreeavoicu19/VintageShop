using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VintageShop.IServices;
using VintageShop.IRepositories;
using VintageShop.Models;
using VintageShop.Data;
using Microsoft.EntityFrameworkCore;

namespace VintageShop.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly StoreDbContext Db;

        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(StoreDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            entity.IsDeleted = true;
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public List<TEntity> GetAllActive()
        {
            return DbSet.Where(x => !x.IsDeleted).ToList();
        }

        public bool SaveCh()
        {
            return (Db.SaveChanges() > 0);
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}