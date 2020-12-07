using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Interfaces.Service
{
    public interface IAuthorService : IBaseService<Guid, Author>
    {
    }
}
