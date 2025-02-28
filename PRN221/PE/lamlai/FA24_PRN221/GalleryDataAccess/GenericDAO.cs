using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GalleryDataAccess
{
    public class GenericDAO<T> : SingletonBase<T> where T : class, new() 
    {
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();
            try
            {
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _context.Set<T>();
            try
            {
                query = query.Where(filter);
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var keyProperty = GetPrimaryKeyProperty();
            if (keyProperty == null)
            {
                throw new InvalidOperationException("No key property found for entity.");
            }

            var keyValue = keyProperty.GetValue(entity);
            if (keyValue == null)
            {
                throw new InvalidOperationException("Key value cannot be null.");
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                var trackedEntity = await _context.Set<T>().FindAsync(keyValue);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity).State = EntityState.Detached;
                }
                _context.Attach(entity).State = EntityState.Modified;
            }
            else
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        private PropertyInfo? GetPrimaryKeyProperty()
        {
            var entityType = _context.Model.FindEntityType(typeof(T));
            if (entityType == null) return null;

            var primaryKey = entityType.FindPrimaryKey();
            if (primaryKey == null) return null;

            var pkProperty = primaryKey.Properties.FirstOrDefault();
            return pkProperty?.PropertyInfo;
        }
    }
}
