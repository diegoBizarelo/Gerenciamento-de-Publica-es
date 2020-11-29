using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Author : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public IEnumerable<BookAuthor> BooksAuthors { get; set; }
    }
}
