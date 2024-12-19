using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IPostRepository Post { get; }
		IFollowRepository Follow { get; }
		ILikeRepository Like { get; }
		ICommentRepository Comment { get; }

		Task SaveAsync();
	}
}
