using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User?> GetUserByIdAsync(string id);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string id);
        Task<User?> GetUserByCredentials(string userId, string password);
        Task<User?> FindExistingUserAsync(User user);

    }
}
