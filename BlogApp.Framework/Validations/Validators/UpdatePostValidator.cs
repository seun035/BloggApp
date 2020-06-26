using BlogApp.Core.Posts.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Framework.Validations.Validators
{
    public class UpdatePostValidator: AbstractValidator<UpdatePostModel>
    {
        public UpdatePostValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

            RuleFor(p => p.Title).NotEmpty();

            RuleFor(p => p.Content).NotEmpty();
        }
    }
}
