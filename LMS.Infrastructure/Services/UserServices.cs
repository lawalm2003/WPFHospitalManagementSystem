using HMS.App.IServices;
using HMS.Domain.IRepositories;
using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services
{
    public class UserServices : IUserService
    {
        private readonly IBaseRepo<User> _userRepo;

        public UserServices(IBaseRepo<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var existingUser = await FindExistingUserAsync(user);

            if (existingUser != null)
            {

                return false;
            }
            return await _userRepo.CreateAsync(user);
            
        }

        public async Task<User?> GetUserByCredentials(string userId, string password)
        {
            // Query the database to find a user with the provided userId and password
            var user = (await _userRepo.GetAllAsync())
                .FirstOrDefault(u => u.UserId == userId && u.Password == password);
            return user;
        }



        public async Task<User?> FindExistingUserAsync(User user)
        {
            // Query the database to find a doctor with identical properties
            var users = await _userRepo.GetAllAsync();

            return users.FirstOrDefault(d =>
                d.UserId == user.UserId &&
                d.Password == user.Password);
        }




        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user != null)
            {
                return await _userRepo.DeleteAsync(user);
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _userRepo.GetByIdAsync(id);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            return await _userRepo.UpdateAsync(user);
        }
    }
}
