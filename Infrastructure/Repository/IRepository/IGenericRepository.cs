using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.IRepository
{
		public interface IGenericRepository<T> where T : class
		{
			Task<T> GetAsync(Guid id);
			Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
			Task<IEnumerable<T>> GetAllAsyncQuery(Expression<Func<T, bool>>? filter = null);
			Task AddAsync(T entity);
			Task AddRangeAsync(IEnumerable<T> entities);
			Task RemoveAsync(Guid id);
			Task RemoveRangeAsync(IEnumerable<T> entities);
		    Task UpdateAsync(Guid id, T updatedEntity);

		}
}
