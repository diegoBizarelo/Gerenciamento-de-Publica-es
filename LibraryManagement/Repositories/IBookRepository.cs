using LibraryManagement.Interfaces.Repository;
using LibraryManagement.Models;
using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository : IRepository<Guid, Book>
    {
    }
}
