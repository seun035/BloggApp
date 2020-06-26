using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Comments
{
    public interface ICommentService
    {
        Task<Guid> AddCommentAsync(Guid postId, SaveCommentModel model);

        Task UpdateCommentAsync(UpdateCommentModel model);

        Task<Comment> GetCommentAsync(Guid commentId);

        Task<Paged<Comment>> SearchAsync(CommentQuery query);

        Task DeleteCommentAsync(Guid commentId);
    }
}
