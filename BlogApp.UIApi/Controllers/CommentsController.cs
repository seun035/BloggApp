using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Core.Comments;
using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.UIApiServices.Comments;
using BlogApp.UIApiServices.Comments.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UIApi.Controllers
{
    [Route("posts/{postId:Guid}/comments")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentManager _commentManager;
        private readonly ICommentComposerService _commentComposerService;

        public CommentsController(ICommentManager commentManager, ICommentComposerService commentComposerService)
        {
            _commentManager = commentManager;
            _commentComposerService = commentComposerService;
        }

        [HttpPost]
        public Task<Guid> AddComment(Guid postId, [FromBody] SaveCommentModel model)
        {
            return _commentManager.AddCommentAsync(postId, model);
        }

        [HttpPut("{commentId:Guid}")]
        public Task UpdateComment(Guid commentId, [FromBody] SaveCommentModel model)
        {
            return _commentManager.AddCommentAsync(commentId, model);
        }

        [HttpGet("~/post/comments/_search")]
        public async Task<Paged<CommentViewModel>> Search([FromQuery] CommentQuery query)
        {
            return await _commentComposerService.SearchAsync(query);
        }

        [HttpDelete("{commentId:Guid}")]
        public Task DeleteComment(Guid commentId)
        {
            return _commentManager.DeleteCommentAsync(commentId);
        }

    }
}