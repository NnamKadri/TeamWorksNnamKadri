using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using NewsPostApp.Entities;

namespace Infrastructure.Repository
{
	public class PostRepository : GenericRepository<Post>, IPostRepository
		{
			private AppDbContext _dbContext;
			public PostRepository(AppDbContext dbContext) : base(dbContext)
			{
				_dbContext = dbContext;
			}
	}
}
