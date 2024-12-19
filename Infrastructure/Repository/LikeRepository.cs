using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using NewsPostApp.Entities;

namespace Infrastructure.Repository
{
	public class LikeRepository : GenericRepository<Like>, ILikeRepository
	{
		private AppDbContext _dbContext;
		public LikeRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
