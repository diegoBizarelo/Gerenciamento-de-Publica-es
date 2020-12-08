using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagementDATA.DataContect;
using LibraryManagementDATA.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementDATA.Implementations
{
    public class BookImplementation : BaseRepository<Guid, Book>, IBookRepository
    {
        private readonly DbSet<Book> _dataset;
        public BookImplementation(LibraryManagementContext db) : base(db)
        {
            _dataset = db.Set<Book>();
        }
    }
}
