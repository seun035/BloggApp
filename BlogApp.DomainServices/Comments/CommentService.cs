using BlogApp.Core.Comments;
using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Framework;
using BlogApp.Core.Helpers;
using BlogApp.Core.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUserContext _userContext;
        private readonly IValidatorFactory _validatorFactory;

        public CommentService(ICommentRepository commentRepository,
                              IUserContext userContext,
                              IValidatorFactory validatorFactory)
        {
            _commentRepository = commentRepository;
            _userContext = userContext;
            _validatorFactory = validatorFactory;
        }

        public async Task<Guid> AddCommentAsync(Guid postId, SaveCommentModel model)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));
            ArgumentGuard.NotNull(model, nameof(model));

            await _validatorFactory.ValidateAsync(model);

            var commentEntity = new CommentEntity
            {
                Id = Guid.NewGuid(),
                Content = model.Content,
                AuthorId = _userContext.UserId,
                PostId = postId,
                CreatedDateUtc = DateTime.UtcNow,
                LastModfiedById = _userContext.UserId,
            };

            return await _commentRepository.AddAsync(commentEntity);
        }

        public async Task UpdateCommentAsync(UpdateCommentModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));
            ArgumentGuard.NotEmpty(model.Id, nameof(model.Id));

            // validate

            var commentEntity = await _commentRepository.GetAsync(model.Id);

            var shouldUpdate = UpdateCommentEntity(commentEntity, model);

            if (!shouldUpdate)
            {
                return;
            }

            commentEntity.LastModfiedById = _userContext.UserId;
            commentEntity.LastModifiedDateUtc = DateTime.UtcNow;

            await _commentRepository.UpdateAsync(commentEntity);


        }

        public async Task<Comment> GetCommentAsync(Guid commentId)
        {
            ArgumentGuard.NotEmpty(commentId, nameof(commentId));

            var commentEntity = await _commentRepository.GetAsync(commentId);
            return new Comment(commentEntity);
        }

        public async Task<Paged<Comment>> SearchAsync(CommentQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));

            var commentDbQuery = ToDbQuery(query);

            return await _commentRepository.SearchAsync(commentDbQuery);
        }

        public async Task DeleteCommentAsync(Guid commentId)
        {
            ArgumentGuard.NotEmpty(commentId, nameof(commentId));

            await _commentRepository.DeleteAsync(commentId);
        }

        private CommentDbQuery ToDbQuery(CommentQuery query)
        {
            return new CommentDbQuery
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                PostId = query.PostId,
                CommentId = query.CommentId
            };
        }

        private bool UpdateCommentEntity(CommentEntity commentEntity, UpdateCommentModel updateCommentModel)
        {
            var requireUpdate = false;

            if (commentEntity.Content != updateCommentModel.Content)
            {
                commentEntity.Content = updateCommentModel.Content;
                requireUpdate = true;
            }

            return requireUpdate;
        }
    }
}
