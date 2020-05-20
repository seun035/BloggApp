using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.Core.Helpers
{
    public static class ArgumentGuard
    {
        public static void NotNull<T>(T argument, string argumentName)
            where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException($"'{argumentName}' can't be null");
            }
        }

        public static void NotEmpty(Guid value, string argumentName)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentNullException($"'{argumentName}' can't be empty");
            }
        }

        public static void NotDefault<T>(T value, string argumentName)
            where T : struct
        {
            if (value.Equals(default(T)))
            {
                throw new ArgumentNullException($"'{argumentName}' can't be empty");
            }
        }

        public static void NotNullOrDefault<T>(T? argument, string argumentName)
            where T : struct
        {
            if (argument == null || argument.Value.Equals(default(T)))
            {
                throw new ArgumentNullException($"'{argumentName}' can't be null or empty");

            }
        }

        public static void NotNullOrEmpty<T>(IEnumerable<T> argument, string argumentName)
        {
            if (argument == null || !argument.Any())
            {
                throw new ArgumentException($"Element in '{argumentName}' can't be null or empty");
            }
        }
    }
}
