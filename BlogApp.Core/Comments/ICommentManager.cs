using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Comments
{
    public interface ICommentManager
    {
        Task<Guid> AddCommentAsync(Guid postId, SaveCommentModel model);

        Task UpdateCommentAsync(UpdateCommentModel model);

        Task<Paged<Comment>> GetComments(Guid postId);

        Task<Paged<Comment>> SearchAsync(CommentQuery query);

        Task DeleteCommentAsync(Guid commentId);
    }
}
