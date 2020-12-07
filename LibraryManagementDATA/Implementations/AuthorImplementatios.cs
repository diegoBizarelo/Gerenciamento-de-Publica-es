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
    public class AuthorImplementatios : BaseRepository<Guid, Author>, IAuthorRepository
    {
        private readonly DbSet<Author> _dataset;

        public AuthorImplementatios(LibraryManagementContext context) : base(context)
        {
            _dataset = context.Set<Author>();
        }
    }
}
