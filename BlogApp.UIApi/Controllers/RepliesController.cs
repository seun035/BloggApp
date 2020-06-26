using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Core.Replies;
using BlogApp.Core.Replies.Models;
using BlogApp.UIApiServices.Replies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UIApi.Controllers
{
    [Route("comments/{commentId:Guid}/replies")]
    [ApiController]
    [Authorize]
    public class RepliesController : ControllerBase
    {
        private readonly IReplyManager _replyManager;
        private readonly IReplyComposerService _replyComposerService;

        public RepliesController(IReplyManager replyManager, IReplyComposerService replyComposerService)
        {
            _replyManager = replyManager;
            _replyComposerService = replyComposerService;
        }

        [HttpPost()]
        public async Task<Guid> AddReply(Guid commentId, [FromBody]SaveReplyModel saveReplyModel)
        {
            return await _replyManager.AddReply(commentId, saveReplyModel);
        }

        [HttpPut("{replyId:Guid}")]
        public Task UpdateReply(Guid replyId, [FromBody]SaveReplyModel saveReplyModel)
        {
            return _replyComposerService.UpdateReplyAsync(saveReplyModel, replyId);
        }

        [HttpDelete("~/reply/{replyId}")]
        public Task DeleteReply(Guid replyId)
        {
            return _replyManager.DeleteReplyAsync(replyId);
        }
    }
}