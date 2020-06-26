using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public class TagRepository: DataRepository<TagEntity>, ITagRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public TagRepository(BlogDbContext blogDbContext)
            :base(blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public void RemoveTagsAsync(IEnumerable<TagEntity> tags)
        {
            ArgumentGuard.NotNull(tags, nameof(tags));

            _blogDbContext.RemoveRange(tags);
        }
    }
}
