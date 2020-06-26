using AutoMapper;
using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts;
using BlogApp.Core.Posts.Models;
using BlogApp.UIApiServices.Posts.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UIApiServices.Posts
{
    public class PostComposerService : IPostComposerService
    {
        private readonly IPostManager _postManager;
        private readonly IMapper _mapper;

        public PostComposerService(IPostManager postManager, IMapper mapper)
        {
            _postManager = postManager;
            _mapper = mapper;
        }

        public async Task<PostViewModel> GetPostAsync(Guid postId)
        {
            var post = await _postManager.GetPost(postId);
            return _mapper.Map<PostViewModel>(post);
        }

        public async Task<Paged<PostViewModel>> SearchAsync(PostQuery query)
        {
            var posts = await _postManager.SearchAsync(query);
            return _mapper.Map<Paged<PostViewModel>>(posts);
        }

        public async Task UpdatePostAsync(SavePostModel model, Guid postId)
        {
            var updatePostModel = new UpdatePostModel
            {
                Id = postId,
                Content = model.Content,
                Status = model.Status,
                Tags = model.Tags,
                Title = model.Title
            };

            await _postManager.UpdatePostAsync(updatePostModel);
        }
    }

    public interface IPostComposerService
    {
        Task<PostViewModel> GetPostAsync(Guid postId);

        Task<Paged<PostViewModel>> SearchAsync(PostQuery query);

        Task UpdatePostAsync(SavePostModel model, Guid postId);
    }
}
