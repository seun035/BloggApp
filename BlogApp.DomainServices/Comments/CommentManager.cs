using BlogApp.Core.Comments;
using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Helpers;
using BlogApp.Core.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Comments
{
    public class CommentManager : ICommentManager
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public CommentManager(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        public async Task<Guid> AddCommentAsync(Guid postId, SaveCommentModel model)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));
            ArgumentGuard.NotNull(model, nameof(model));

            var post = await _postService.GetPostAsync(postId);

            // permission

           return await _commentService.AddCommentAsync(post.Id, model);
        }

        public Task<Paged<Comment>> GetComments(Guid postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Paged<Comment>> SearchAsync(CommentQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));
            // permission
            return await _commentService.SearchAsync(query);
        }

        public async Task UpdateCommentAsync(UpdateCommentModel model)
        {
            ArgumentGuard.NotNull(model, nameof(model));
            ArgumentGuard.NotEmpty(model.Id, nameof(model.Id));

            // permissions

            await _commentService.UpdateCommentAsync(model);
        }

        public async Task DeleteCommentAsync(Guid commentId)
        {
            ArgumentGuard.NotEmpty(commentId, nameof(commentId));

            // permissions

            await _commentService.DeleteCommentAsync(commentId);
        }
    }
}
