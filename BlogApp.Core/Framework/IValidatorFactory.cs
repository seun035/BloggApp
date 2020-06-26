using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Framework
{
    public interface IValidatorFactory
    {
        object CreateValidator<TModel>();

        Task ValidateAsync<TModel>(TModel model);
    }
}
