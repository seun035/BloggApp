using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Common.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedDateUtc { get; set; }

        public DateTime? DeletedDateUtc { get; set; }
    }
}
