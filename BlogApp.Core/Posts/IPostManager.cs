using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Posts
{
    public interface IPostManager
    {
        Task CreatePostAsync(SavePostModel savePostModel);

        Task UpdatePostAsync(UpdatePostModel updatePostModel);

        Task<Post> GetPost(Guid postId);

        Task<Paged<Post>> SearchAsync(PostQuery query);

        Task DeletePostAsync(Guid postId);
    }
}
