using AutoMapper;
using BlogApp.Core.Comments;
using BlogApp.Core.Comments.Models;
using BlogApp.Core.Common.Models;
using BlogApp.UIApiServices.Comments.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UIApiServices.Comments
{
    public class CommentComposerService: ICommentComposerService
    {
        private readonly ICommentManager _commentManager;
        private readonly IMapper _mapper;

        public CommentComposerService(ICommentManager commentManager, IMapper mapper)
        {
            _commentManager = commentManager;
            _mapper = mapper;
        }

        public async Task<Paged<CommentViewModel>> SearchAsync(CommentQuery query)
        {
            var result = await _commentManager.SearchAsync(query);

            return _mapper.Map<Paged<CommentViewModel>>(result);
        }

        public async Task UpdateAsync(Guid commentId, SaveCommentModel saveCommentModel)
        {
            var updateCommentModel = new UpdateCommentModel
            {
                Id = commentId,
                Content = saveCommentModel.Content
            };

            await _commentManager.UpdateCommentAsync(updateCommentModel);
        }
    }

    public interface ICommentComposerService
    {
        Task<Paged<CommentViewModel>> SearchAsync(CommentQuery query);

        Task UpdateAsync(Guid commentId, SaveCommentModel saveCommentModel);
    }
}
