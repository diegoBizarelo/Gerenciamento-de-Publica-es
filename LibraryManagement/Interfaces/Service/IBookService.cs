using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Interfaces.Service
{
    public interface IBookService : IBaseService<Guid, Book>
    {
        
    }
}
