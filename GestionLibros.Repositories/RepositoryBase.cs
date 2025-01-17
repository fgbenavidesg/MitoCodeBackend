﻿using GestionLibros.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly DbContext dbContext;

        public RepositoryBase(DbContext dbContext) {
            this.dbContext = dbContext;
        }

        public  async Task<ICollection<TEntity>> GetAsync()
        {
            return await dbContext.Set<TEntity>()
             .AsNoTracking()
             .IgnoreQueryFilters()
             .ToListAsync();
        }
        public virtual async Task<TEntity?> GetAsync(string id)
        {
            return await dbContext.Set<TEntity>()
            .FindAsync(id);
        }
        public  async Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> orderBy)
        {
            return await dbContext.Set<TEntity>()
                .Where(predicate)
                .OrderBy(orderBy)
                .AsNoTracking()
                .ToListAsync();
        }
        public virtual async Task<string> AddAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>()
                 .AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var item = await GetAsync(id);

            if (item is not null)
            {
                item.Status = false;
                await UpdateAsync();
            }
        }
        public virtual async Task UpdateAsync()
        {
          await dbContext.SaveChangesAsync();
        }
        
    }
}
