using BlogApp.Core.Data;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Repositories
{
    public class PostRepository: DataRepository<PostEntity>, IPostRepository
    {
        public PostRepository(BlogDbContext blogDbContext)
            :base(blogDbContext)
        {

        }
    }
}
