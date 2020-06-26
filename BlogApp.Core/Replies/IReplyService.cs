using BlogApp.Core.Replies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Replies
{
    public interface IReplyService
    {
        Task<Guid> AddReplyAsync(Guid commentId, SaveReplyModel model);

        Task UpdateReplyAsync(UpdateReplyModel updateReplyModel);

        Task DeleteReplyAsync(Guid replyId);
    }
}
