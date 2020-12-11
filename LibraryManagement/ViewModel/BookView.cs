using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.ViewModel
{
    public class BookView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int? Year { get; set; }
        public IEnumerable<AuthorView> Authors { get; set; }
        

        public BookView()
        {
            Authors = new List<AuthorView>();
        }
    }
}
