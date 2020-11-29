using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Models
{
    public class Book : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public IEnumerable<BookAuthor> BooksAuthors { get; set; }
    }
}
