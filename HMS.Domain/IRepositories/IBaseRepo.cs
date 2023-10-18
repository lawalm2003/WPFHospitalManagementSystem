using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.IRepositories
{
    public interface IBaseRepo<T> where T : BaseModel
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<IEnumerable<T?>> GetAllAsync();
        Task<T?> GetByIdAsync(string id);
        Task<bool> UpdateAsync(T entity);
    }
}
