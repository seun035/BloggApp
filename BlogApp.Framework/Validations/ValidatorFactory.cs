using Autofac;
using BlogApp.Core.Framework;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Framework.Validations
{
    public class ValidatorFactory : Core.Framework.IValidatorFactory
    {
        private readonly IComponentContext _context;

        public ValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public object CreateValidator<TModel>()
        {
            IValidator<TModel> validator;

            if (_context.TryResolve(out validator))
            {
                return validator;
            }

            return null; 
        }

        public async Task ValidateAsync<TModel>(TModel model)
        {
            var validator = CreateValidator<TModel>();

            if (validator == null)
            {
                throw new InvalidOperationException($"No validator found for {typeof(TModel).Name}");
            }

            var result = await (validator as IValidator<TModel>).ValidateAsync(model);

            if (!result.IsValid)
            {
                IDictionary<string, string> errors = new Dictionary<string, string>();

                foreach (var item in result.Errors)
                {
                    errors.Add(item.PropertyName, item.ErrorMessage);
                }

                throw new Core.Exceptions.ValidationException(errors: errors);
            }
        }
    }
}
