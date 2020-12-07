using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.ViewModel
{
    public class AuthorView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public IEnumerable<BookView> Books { get; set; }
    }
}
