using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Repositories
{
    public class CommentRepository : DataRepository<CommentEntity>, ICommentRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public CommentRepository(BlogDbContext blogDbContext) 
            :base(blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public async Task<Paged<Comment>> SearchAsync(CommentDbQuery commentDbQuery)
        {
            ArgumentGuard.NotNull(commentDbQuery, nameof(commentDbQuery));

            var query = _blogDbContext.Comments.AsQueryable();

            if (commentDbQuery.PostId != default)
            {
                query = query.Where(c => c.PostId == commentDbQuery.PostId);
            }

            if (commentDbQuery.CommentId.HasValue)
            {
                query = query.Where(c => c.Id == commentDbQuery.CommentId);
            }

            var totalCount = query?.Count() ?? default(long);
            var results = await query.Skip(commentDbQuery.PageSize * (commentDbQuery.PageNumber - 1)).Take(commentDbQuery.PageSize).ToListAsync();
            var comments = results.Select(x => new Comment(x)).ToList();

            return new Paged<Comment> { PageSize = commentDbQuery.PageSize, PageNumber = commentDbQuery.PageNumber, TotalCount = totalCount, Items = comments };
        }
    }
}
