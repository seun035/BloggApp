using BlogApp.Core.Data;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Repositories
{
    public class TagRepository: DataRepository<TagEntity>, ITagRepository
    {
        public TagRepository(BlogDbContext blogDbContext)
            :base(blogDbContext)
        {

        }
    }
}
