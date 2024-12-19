using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using NewsPostApp.Entities;

namespace Infrastructure.Repository
{
	public class FollowRepository : GenericRepository<Follow>, IFollowRepository
	{
		private AppDbContext _dbContext;
		public FollowRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
