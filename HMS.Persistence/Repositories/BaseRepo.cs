using HMS.Domain.IRepositories;
using HMS.Domain.Model;
using HMS.Persistence.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HMS.Persistence.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseModel
    {
        private readonly HMSContext _context;

        public BaseRepo(HMSContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Handle the exception, log it, and return false or throw an exception.
                // In WPF, you might use a logging framework or display error messages to the user.
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Handle the exception, log it, and return false or throw an exception.
                // In WPF, you might use a logging framework or display error messages to the user.
                return false;
            }
        }

        public async Task<IEnumerable<T?>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Handle the exception, log it, and return false or throw an exception.
                // In WPF, you might use a logging framework or display error messages to the user.
                return false;
            }
        }
    }
}
