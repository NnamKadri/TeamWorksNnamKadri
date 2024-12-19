﻿using NewsPostApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.IRepository
{
	public interface ICommentRepository : IGenericRepository<Comment>
	{
	}
}
