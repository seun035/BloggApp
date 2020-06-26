using BlogApp.Core.Comments.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Framework.Validations.Validators
{
    public class SaveCommentValidator: AbstractValidator<SaveCommentModel>
    {
        public SaveCommentValidator()
        {
            RuleFor(c => c.Content).NotEmpty();

            RuleFor(c => c.Content).MaximumLength(500);
        }
    }
}
