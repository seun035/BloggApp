using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Posts
{
    public interface IPostService
    {
        Task CreatePostAsync(SavePostModel savePostModel);

        Task UpdatePostAsync(UpdatePostModel updatePostModel);

        Task<Post> GetPostAsync(Guid postId);

        Task<Paged<Post>> SearchAsync(PostQuery query);

        Task DeletePostAsync(Guid postId);
    }
}
