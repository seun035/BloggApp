using BlogApp.Core.Posts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Data
{
    public interface ITagRepository: IDataRepository<TagEntity>
    {
        void RemoveTagsAsync(IEnumerable<TagEntity> tags);
    }
}
