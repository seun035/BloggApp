using BlogApp.Core.Common.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Helpers;
using BlogApp.Core.Posts;
using BlogApp.Core.Posts.Models;
using BlogApp.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DomainServices.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserContext _userContext;

        public PostService(IPostRepository postRepository, IUserContext userContext)
        {
            _postRepository = postRepository;
            _userContext = userContext;
        }

        public async Task CreatePostAsync(SavePostModel savePostModel)
        {
            ArgumentGuard.NotNull(savePostModel, nameof(savePostModel));

            // validate

            var post = new PostEntity
            {
                Id = Guid.NewGuid(),
                Title = savePostModel.Title,
                Content = savePostModel.Content,
                Status = PostStatus.Draft,
                Tags = savePostModel.Tags.Select(t => new TagEntity { Id = Guid.NewGuid(), Name = t }).ToList(),
                CreatedDateUtc = DateTime.UtcNow,
                AuthorId = _userContext.UserId
            };

            await _postRepository.AddAsync(post);
        }

        public async Task<Post> GetPostAsync(Guid postId)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));
            var postEntity = await _postRepository.GetAsync(postId);

            return new Post(postEntity);
        }

        public async Task<Paged<Post>> SearchAsync(PostQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));

            var dbQuery = ToDbQuery(query);

            return await _postRepository.SearchAsync(dbQuery);
        }

        public async Task UpdatePostAsync(SavePostModel savePostModel, Guid postId)
        {
            ArgumentGuard.NotNull(savePostModel, nameof(savePostModel));
            ArgumentGuard.NotEmpty(postId, nameof(postId));

            var postEntity = await _postRepository.GetAsync(postId);

            postEntity.Title = savePostModel.Title;
            postEntity.Status = savePostModel.Status;
            postEntity.Content = savePostModel.Content;
            postEntity.LastModfiedById = _userContext.UserId;
            postEntity.LastModifiedDateUtc = DateTime.UtcNow;
            postEntity.Tags = savePostModel.Tags.Select(x => new TagEntity { Id = Guid.NewGuid(), Name = x }).ToList();

            await _postRepository.UpdateAsync(postEntity);
        }

        public async Task DeletePostAsync(Guid postId)
        {
            await _postRepository.DeleteAsync(postId);
        }

        private PostDbQuery ToDbQuery(PostQuery query)
        {
            return new PostDbQuery
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                SearchText = query.SearchText,
                Status = query.Status
            };
        }
    }
}
