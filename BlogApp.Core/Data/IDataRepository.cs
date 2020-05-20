using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Data
{
    public interface IDataRepository<T>
        where T : BaseEntity
    {
        Task<Guid> AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<T> GetAsync(Guid entityId, bool allowNull = false);

        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool allowNull = false);

        Task<IList<T>> FindAllAsync();

        Task<IList<T>> FindAllAsync(Expression<Func<T, bool>> expression);

        Task UpdateAsync(T entity);
    }
}
