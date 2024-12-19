using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using NewsPostApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{


	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{

		private readonly AppDbContext db;


		public GenericRepository(AppDbContext dbContext)
		{
			db = dbContext;
		}

		public async Task AddAsync(T entity)
		{
			ArgumentNullException.ThrowIfNull(entity);
			db.Set<T>().Add(entity);
			await db.SaveChangesAsync();
		}

		public async Task AddRangeAsync(IEnumerable<T> entities)
		{
			ArgumentNullException.ThrowIfNull(entities);

			if (!entities.Any())
			{
				return;
			}

			db.Set<T>().AddRange(entities);
			await db.SaveChangesAsync();
		}

		
	

		public async Task<IEnumerable<T>> GetAllAsyncQuery(Expression<Func<T, bool>>? filter = null)
		{
			IQueryable<T> query = db.Set<T>();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return await query.ToListAsync();

		}

		public async Task<T> GetAsync(Guid id)
		{
			if ( id == Guid.Empty)
			{
				return default;
			}
			var item = await db.Set<T>().FindAsync(id);
			if (item == null)
			{
				return default;
			}

			return item;
		}

		

		public async Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter,string? includeProperties = null)
		{
			IQueryable<T> query = db.Set<T>();

			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProperty);
				}
			}

			return await query.FirstOrDefaultAsync(filter);
		}


		public async Task RemoveAsync(Guid id)
		{
            if (id == Guid.Empty)
            {
				return; 
            }
            var entity = await db.Set<T>().FindAsync(id);
			ArgumentNullException.ThrowIfNull(entity);
			// Set IsDeleted to true to mark it as soft deleted
			entity.IsDeleted = true;

			db.Set<T>().Update(entity);
			await db.SaveChangesAsync();
		}

		

		public async Task RemoveRangeAsync(IEnumerable<T> entities)
		{
			ArgumentNullException.ThrowIfNull(entities);

			if (!entities.Any())
			{
				return;
			}

			db.Set<T>().RemoveRange(entities);
			await db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Guid id, T updatedEntity)
		{
			if (id == Guid.Empty)
			{
				return;
			}

			var entity = await db.Set<T>().FindAsync(id);
			ArgumentNullException.ThrowIfNull(entity);

			// Update the entity's properties with the new values from updatedEntity
			db.Entry(entity).CurrentValues.SetValues(updatedEntity);

			await db.SaveChangesAsync();
		}


	}
}
