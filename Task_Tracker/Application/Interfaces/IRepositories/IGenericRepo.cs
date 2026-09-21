using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Repositories
{
    public interface IGenericRepo<T> where T : class
    {
        public Task AddAsync(T  item);
        public bool Update(T uItem);
        public Task<bool> DeleteAsync(int id);
        public Task<T> GetByIdAsync(int id);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
