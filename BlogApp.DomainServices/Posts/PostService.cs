using BlogApp.Core.Common.Models;
using BlogApp.Core.Data;
using BlogApp.Core.Framework;
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
        private readonly ITagRepository _tagRepository;
        private readonly IValidatorFactory _validatorfactory;
        private readonly IUserContext _userContext;

        public PostService(
            IPostRepository postRepository,
            ITagRepository tagRepository,
            IValidatorFactory validatorfactory,
            IUserContext userContext)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _validatorfactory = validatorfactory;
            _userContext = userContext;
        }

        public async Task CreatePostAsync(SavePostModel savePostModel)
        {
            ArgumentGuard.NotNull(savePostModel, nameof(savePostModel));

            await _validatorfactory.ValidateAsync(savePostModel);

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
            var tagsEntity = await _tagRepository.FindAllAsync(t => t.PostId == postId);

            if (tagsEntity.Any())
            {
                postEntity.Tags = tagsEntity;
            }

            return new Post(postEntity);
        }

        public async Task<Paged<Post>> SearchAsync(PostQuery query)
        {
            ArgumentGuard.NotNull(query, nameof(query));

            var dbQuery = ToDbQuery(query);

            return await _postRepository.SearchAsync(dbQuery);
        }

        public async Task UpdatePostAsync(UpdatePostModel updatePostModel)
        {
            ArgumentGuard.NotNull(updatePostModel, nameof(updatePostModel));
            ArgumentGuard.NotEmpty(updatePostModel.Id, nameof(updatePostModel.Id));

            await _validatorfactory.ValidateAsync(updatePostModel);

            var postEntity = await _postRepository.GetPostAsync(updatePostModel.Id);
           
            postEntity.Title = updatePostModel.Title;
            postEntity.Status = updatePostModel.Status;
            postEntity.Content = updatePostModel.Content;
            postEntity.LastModfiedById = _userContext.UserId;
            postEntity.LastModifiedDateUtc = DateTime.UtcNow;

            _tagRepository.RemoveTagsAsync(postEntity.Tags);

            foreach (var tag in updatePostModel.Tags)
            {
                await _tagRepository.AddAsync(new TagEntity { Id = Guid.NewGuid(), Name = tag, PostId = updatePostModel.Id });
            }

            await _postRepository.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Guid postId)
        {
            ArgumentGuard.NotEmpty(postId, nameof(postId));

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
