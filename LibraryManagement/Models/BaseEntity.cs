using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public abstract class BaseEntity<TKey>
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
