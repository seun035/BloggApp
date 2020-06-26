using BlogApp.Core.Data;
using BlogApp.Core.Replies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Repositories
{
    public class ReplyRepository : DataRepository<ReplyEntity>, IReplyRepository
    {
        public ReplyRepository(BlogDbContext blogDbContext) 
            : base(blogDbContext)
        {
        }
    }
}
