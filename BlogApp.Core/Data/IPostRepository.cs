using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Data
{
    public interface IPostRepository: IDataRepository<PostEntity>
    {
    }
}
