using BlogApp.Core.Common.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public abstract class DataRepository<T> : IDataRepository<T>
        where T: BaseEntity
    {
        private readonly BlogDbContext _blogDbContext;

        public DataRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<Guid> AddAsync(T entity)
        {
            ArgumentGuard.NotNull(entity, nameof(entity));
            
            await _blogDbContext.Set<T>().AddAsync(entity);
            await _blogDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            ArgumentGuard.NotNullOrEmpty(entities, nameof(entities));

            await _blogDbContext.Set<T>().AddRangeAsync(entities);
            await _blogDbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> FindAllAsync()
        {
            return await _blogDbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> FindAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            ArgumentGuard.NotNull(expression, nameof(expression));

            return await _blogDbContext.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetAsync(Guid entityId, bool allowNull = false)
        {
            ArgumentGuard.NotEmpty(entityId, nameof(entityId));

            T entity = await _blogDbContext.Set<T>().FindAsync(entityId);

            if (entity == null && !allowNull)
            {
                throw new NullReferenceException(); //change to app defined exception
            }

            return entity;
        }

        public async Task<T> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> expression, bool allowNull = false)
        {
            ArgumentGuard.NotNull(expression, nameof(expression));

            T entity = await _blogDbContext.Set<T>().SingleOrDefaultAsync(expression);

            if (entity == null && !allowNull)
            {
                throw new NullReferenceException(); //change to app defined exception
            }

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            ArgumentGuard.NotNull(entity, nameof(entity));

            _blogDbContext.Entry<T>(entity).State = EntityState.Modified;
            await _blogDbContext.SaveChangesAsync();
        }
    }
}
