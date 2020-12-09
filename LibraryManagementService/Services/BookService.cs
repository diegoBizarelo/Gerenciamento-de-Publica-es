using LibraryManagement.Interfaces.Service;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using LibraryManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementService.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Delete(Guid id)
        {
            var r = await _bookRepository.DeleteAsync(id);
            return r;
        }

        public async Task<Book> Get(Guid id)
        {
            var r = await _bookRepository.SelectAsync(id);
            return r;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var r = await _bookRepository.SelectAsync();
            return r;
        }

        public async Task<Book> Post(Book entity)
        {
            var r = await _bookRepository.InsetAsync(entity);
            return r;
        }

        public async Task<Book> Put(Book entity)
        {
            var r = await _bookRepository.UpdateAsnyc(entity);
            return r;
        }
    }
}
