using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IAdminService
    {
        Task<bool> CreateAdminAsync(Admin admin);
        Task<IEnumerable<Admin?>> GetAllAdminAsync();
        Task<Admin?> GetAdminByIdAsync(string id);
        Task<bool> UpdateAdminAsync(Admin admin);
        Task<bool> DeleteAdminAsync(string id);
        Task<bool> IsAdminIdUniqueAsync(string userId);
    }
}
