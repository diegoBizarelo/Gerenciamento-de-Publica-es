using LibraryManagement.Interfaces.Service;
using LibraryManagement.Models;
using LibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementService.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<bool> Delete(Guid id)
        {
            var r = await _authorRepository.DeleteAsync(id);
            return r;
        }

        public async Task<Author> Get(Guid id)
        {
            var r = await _authorRepository.SelectAsync(id);
            return r;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var r = await _authorRepository.SelectAsync();
            return r;
        }

        public async Task<Author> Post(Author entity)
        {
            var r = await _authorRepository.InsetAsync(entity);
            return r;
        }

        public async Task<Author> Put(Author entity)
        {
            var r = await _authorRepository.UpdateAsnyc(entity);
            return r;
        }
    }
}
