using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Interfaces.Repository
{
    public interface IRepository<TKey, T> where T : BaseEntity<TKey>
    {
        Task<T> InsetAsync(T item);
        Task<T> UpdateAsnyc(T item);
        Task<bool> DeleteAsync(TKey id);
        Task<T> SelectAsync(TKey id);
        Task<IEnumerable<T>> SelectAsync();
        Task SaveAsyncChanges();
    }
}
