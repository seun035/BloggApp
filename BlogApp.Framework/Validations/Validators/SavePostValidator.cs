using BlogApp.Core.Posts.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Framework.Validations.Validators
{
    class SavePostValidator : AbstractValidator<SavePostModel>
    {
        public SavePostValidator()
        {
            RuleFor(p => p.Title).NotEmpty();

            RuleFor(p => p.Content).NotEmpty();
        }
    }

}
