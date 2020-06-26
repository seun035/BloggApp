using BlogApp.Core.Common.Models;
using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Data
{
    public interface IPostRepository: IDataRepository<PostEntity>
    {
        Task<Paged<Post>> SearchAsync(PostDbQuery dbQuery);

        Task<PostEntity> GetPostAsync(Guid postId, bool allowNull = false);
    }
}
