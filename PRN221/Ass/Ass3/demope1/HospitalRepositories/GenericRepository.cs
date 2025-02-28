using HospitalDataAccess;
using HospitalRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRepositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly GenericDAO<T> _DAO;
        public GenericRepository()
        {
            _DAO = SingletonBase<GenericDAO<T>>.Instance;
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            return await _DAO.GetAllAsync(filter, includeProperties);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            return await _DAO.GetFirstOrDefaultAsync(filter, includeProperties);
        }

        public async Task AddAsync(T entity)
        {
            await _DAO.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _DAO.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _DAO.DeleteAsync(id);
        }
    }
}

