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

        public async Task AddAsync(T item)
        {
            await _context.AddAsync(item);
        }

        public async void DeleteAsync(int id)
        {
            var item = await _dbset.FindAsync(id);
            if (item == null)
                throw new NullReferenceException("The item can not be found");
            _context.Remove(item);
        }
        public async Task<T> GetByAsync(int id)
        {
           var item = await _dbset.FindAsync(id);
            return item?? throw new NullReferenceException("The item can not be found");
        }

        public bool Update(T uItem)
        {
            _context.Update(uItem);
            return true;
        }

        
    }
}
