using BlogApp.Core.Comments;
using BlogApp.Core.Helpers;
using BlogApp.Core.Replies;
using BlogApp.Core.Replies.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Replies
{
    public class ReplyManager: IReplyManager
    {
        private readonly ICommentService _commentService;
        private readonly IReplyService _replyService;

        public ReplyManager(ICommentService commentService, IReplyService replyService)
        {
            _commentService = commentService;
            _replyService = replyService;
        }

        public async Task<Guid> AddReply(Guid commentId, SaveReplyModel model)
        {
            ArgumentGuard.NotEmpty(commentId, nameof(commentId));
            ArgumentGuard.NotNull(model, nameof(model));

            var comment = await _commentService.GetCommentAsync(commentId);

            // permission
            return await _replyService.AddReplyAsync(commentId, model);
        }

        public async Task UpdateReplyAsync(UpdateReplyModel updateReplyModel)
        {
            ArgumentGuard.NotEmpty(updateReplyModel.Id, nameof(updateReplyModel.Id));
            ArgumentGuard.NotNull(updateReplyModel, nameof(updateReplyModel));

            //permission
            await _replyService.UpdateReplyAsync(updateReplyModel);
        }

        public async Task DeleteReplyAsync(Guid replyId)
        {
            ArgumentGuard.NotEmpty(replyId, nameof(replyId));

            await _replyService.DeleteReplyAsync(replyId);
        }
    }
}
