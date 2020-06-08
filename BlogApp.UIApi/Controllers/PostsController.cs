using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts;
using BlogApp.Core.Posts.Models;
using BlogApp.UIApiServices.Posts;
using BlogApp.UIApiServices.Posts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.UIApi.Controllers
{
    [Route("posts")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostManager _postManager;
        private readonly IPostComposerService _postComposerService;

        public PostsController(IPostManager postManager, IPostComposerService postComposerService)
        {
            _postManager = postManager;
            _postComposerService = postComposerService;
        }

        [HttpPost]
        public async Task AddPost(SavePostModel model)
        {
            await _postManager.CreatePostAsync(model);
        }

        [HttpPut("{postId:Guid}")]
        public Task UpdatePost([FromBody]SavePostModel model, Guid postId)
        {
            return _postManager.UpdatePostAsync(model, postId);
        }

        [HttpGet("{postId:Guid}")]
        public Task<PostViewModel> GetPost(Guid postId)
        {
            return _postComposerService.GetPostAsync(postId);
        }

        [HttpGet("_search")]
        public Task<Paged<PostViewModel>> Search([FromQuery] PostQuery query)
        {
            return _postComposerService.SearchAsync(query);
        }

        [HttpDelete("{postId:Guid}")]
        public Task DeletePost(Guid postId)
        {
           return _postManager.DeletePostAsync(postId);
        }
    }
}