using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Interfaces.Service
{
    public interface IBaseService<TKey, T> where T : BaseEntity<TKey>
    {
        Task<bool> Delete(TKey id);
        Task<T> Get(TKey id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Post(T entity);
        Task<T> Put(T entity);
    }
}
