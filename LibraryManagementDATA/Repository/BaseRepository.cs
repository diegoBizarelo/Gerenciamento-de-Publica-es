using LibraryManagement.Models;
using LibraryManagementDATA.DataContect;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManagement.Interfaces.Repository;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementDATA.Repository
{
    public class BaseRepository<Tkey, T> : IRepository<Tkey, T> where T : BaseEntity<Tkey>
    {
        protected readonly LibraryManagementContext _db;
        protected readonly DbSet<T>  _dbSet;

        public BaseRepository(LibraryManagementContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public virtual async Task<bool> DeleteAsync(Tkey id)
        {
            var result = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
            if (result == null)
            {
                return false;
            }

            _dbSet.Remove(result);
            await _db.SaveChangesAsync();
            return true;
        }

        public virtual async Task<T> InsetAsync(T item)
        {
            try
            {
                item.CreateAt = DateTime.UtcNow;
                await _dbSet.AddAsync(item);
                await _db.SaveChangesAsync();
                return item;
            } 
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task SaveAsyncChanges()
        {
            await _db.SaveChangesAsync();
        }

        public virtual async Task<T> SelectAsync(Tkey id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity ?? null;
        }

        public virtual async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            } 
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<T> UpdateAsnyc(T item)
        {
            try
            {
                var result = await _dbSet.SingleOrDefaultAsync(e => e.Id.Equals(item.Id));
                if ( result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _db.Entry(result).CurrentValues.SetValues(item);
                await _db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }
    }
}
