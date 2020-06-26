using BlogApp.Core.Replies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Replies
{
    public interface IReplyManager
    {
        Task<Guid> AddReply(Guid commentId, SaveReplyModel saveReplyModel);

        Task UpdateReplyAsync(UpdateReplyModel updateReplyModel);

        Task DeleteReplyAsync(Guid replyId);
    }
}
