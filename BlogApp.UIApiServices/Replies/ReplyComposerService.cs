using BlogApp.Core.Replies;
using BlogApp.Core.Replies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UIApiServices.Replies
{
    public class ReplyComposerService: IReplyComposerService
    {
        private readonly IReplyManager _replyManager;

        public ReplyComposerService(IReplyManager replyManager)
        {
            _replyManager = replyManager;
        }

        public async Task UpdateReplyAsync(SaveReplyModel model, Guid replyId)
        {
            var updateReplyModel = new UpdateReplyModel
            {
                Id = replyId,
                Content = model.Content,
            };

            await _replyManager.UpdateReplyAsync(updateReplyModel);
        }
    }

    public interface IReplyComposerService
    {
        Task UpdateReplyAsync(SaveReplyModel model, Guid replyId);
    }
}
