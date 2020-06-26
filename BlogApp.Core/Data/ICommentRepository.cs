using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Data
{
    public interface ICommentRepository: IDataRepository<CommentEntity>
    {
        Task<Paged<Comment>> SearchAsync(CommentDbQuery commentDbQuery);
    }
}
