using BlogApp.Core.Common.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using BlogApp.Core.Posts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public class PostRepository: DataRepository<PostEntity>, IPostRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public PostRepository(BlogDbContext blogDbContext)
            :base(blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<Paged<Post>> SearchAsync(PostDbQuery dbQuery)
        {
            ArgumentGuard.NotNull(dbQuery, nameof(dbQuery));

            var query = _blogDbContext.Posts.Include(p => p.Author).Include(p => p.Tags).AsQueryable();

            if (dbQuery.SearchText != null)
            {
                query = query.Where(p => p.Title.Contains(dbQuery.SearchText) || p.Content.Contains(dbQuery.SearchText) || p.Tags.Any(t => dbQuery.SearchText.Contains(t.Name)));
            }

            if (dbQuery.Status.HasValue)
            {
                query = query.Where(p => p.Status == dbQuery.Status.Value);
            }

            var totalCount = query?.Count() ?? default(long);
            var results = await query.Skip(dbQuery.PageSize * (dbQuery.PageNumber - 1)).Take(dbQuery.PageSize).ToListAsync();

            var posts = results.Select(x => new Post(x)).ToList();

            return new Paged<Post> { PageSize = dbQuery.PageSize, PageNumber = dbQuery.PageNumber, TotalCount = totalCount, Items = posts };
        }

        public async Task<PostEntity> GetPostAsync(Guid postId, bool allowNull = false)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));

            PostEntity post = await _blogDbContext.Posts.Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null && !allowNull)
            {
                throw new NullReferenceException(); //change to app defined exception
            }

            return post;
        }

    }
}
