using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using NewsPostApp.Entities;

namespace Infrastructure.Repository
{
	public class CommentRepository : GenericRepository<Comment>, ICommentRepository
	{
		private AppDbContext _dbContext;
		public CommentRepository(AppDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
