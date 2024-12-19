using Infrastructure.Data;
using Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private AppDbContext _DbContext;	
        public UnitOfWork(AppDbContext DbContext)
        {
            _DbContext = DbContext;
			Post = new PostRepository(_DbContext);
			Comment = new CommentRepository(_DbContext);
			Like = new LikeRepository(_DbContext);
			Follow = new FollowRepository(_DbContext);

		}
        public IPostRepository Post { get; private set; }

		public IFollowRepository Follow { get; private set; }

		public ILikeRepository Like { get; private set; }

		public ICommentRepository Comment { get; private set; }

		public async Task SaveAsync()
		{
			await _DbContext.SaveChangesAsync();
		}
	}
}
