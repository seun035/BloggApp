using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using BlogApp.Core.Replies;
using BlogApp.Core.Replies.Models;
using BlogApp.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Replies
{
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository _replyRepository;
        private readonly IUserContext _userContext;

        public ReplyService(IReplyRepository replyRepository, IUserContext userContext)
        {
            _replyRepository = replyRepository;
            _userContext = userContext;
        }

        public async Task<Guid> AddReplyAsync(Guid commentId, SaveReplyModel model)
        {
            ArgumentGuard.NotEmpty(commentId, nameof(commentId));
            ArgumentGuard.NotNull(model, nameof(model));

            // validation, 

            var replyEntity = new ReplyEntity 
            { 
                AuthorId = _userContext.UserId,
                CommentId = commentId,
                Content = model.Content,
                CreatedDateUtc = DateTime.UtcNow 
            };

            return await _replyRepository.AddAsync(replyEntity);
        }

        public async Task UpdateReplyAsync(UpdateReplyModel updateReplyModel)
        {
            ArgumentGuard.NotEmpty(updateReplyModel.Id, nameof(updateReplyModel.Id));
            ArgumentGuard.NotNull(updateReplyModel, nameof(updateReplyModel));

            // validate

            var replyEntity = await _replyRepository.GetAsync(updateReplyModel.Id);

            var shouldUpdate = UpdateReplyEntity(replyEntity, updateReplyModel);

            if (!shouldUpdate)
            {
                return;
            }

            replyEntity.LastModfiedById = _userContext.UserId;
            replyEntity.LastModifiedDateUtc = DateTime.UtcNow;

            await _replyRepository.UpdateAsync(replyEntity);
        }

        public async Task DeleteReplyAsync(Guid replyId)
        {
            ArgumentGuard.NotEmpty(replyId, nameof(replyId));

            await _replyRepository.DeleteAsync(replyId);
        }

        private bool UpdateReplyEntity(ReplyEntity replyEntity, UpdateReplyModel updateReplyModel)
        {
            var requireUpdate = false;

            if (replyEntity.Content != updateReplyModel.Content)
            {
                replyEntity.Content = updateReplyModel.Content;
                requireUpdate = true;
            }

            return requireUpdate;
        }
    }
}
