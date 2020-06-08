using BlogApp.Core.Common.Models;
using BlogApp.Core.Helpers;
using BlogApp.Core.Posts;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Posts
{
    public class PostManager : IPostManager
    {
        private readonly IPostService _postService;

        public PostManager(IPostService postService)
        {
            _postService = postService;
        }

        public async Task CreatePostAsync(SavePostModel savePostModel)
        {
            ArgumentGuard.NotNull(savePostModel, nameof(savePostModel));

            // permission
            await _postService.CreatePostAsync(savePostModel);
        }

        public async Task<Post> GetPost(Guid postId)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));

            // permission
            return await _postService.GetPostAsync(postId);
        }

        public async Task<Paged<Post>> SearchAsync(PostQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));
            // permission
            return await _postService.SearchAsync(query);
        }

        public async Task UpdatePostAsync(SavePostModel savePostModel, Guid postId)
        {
            ArgumentGuard.NotNull(savePostModel, nameof(savePostModel));
            ArgumentGuard.NotEmpty(postId, nameof(postId));

            //permission
            await _postService.UpdatePostAsync(savePostModel, postId);
        }

        public async Task DeletePostAsync(Guid postId)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));

            //permission
            await _postService.DeletePostAsync(postId);
        }
    }
}
