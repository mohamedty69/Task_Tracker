using Application;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Infrastructure.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected AppDbContext _context;
        protected DbSet<T> _dbset;

        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>(); 
        }

        public async System.Threading.Tasks.Task AddAsync(T item)
        {
            await _context.AddAsync(item);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _dbset.FindAsync(id);
            if (item == null)
                return false;
            _context.Remove(item);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           var item = await _dbset.FindAsync(id);
            return item;
        }

        public bool Update(T uItem)
        {
            _context.Update(uItem);
            return true;
        }

        
    }
}
