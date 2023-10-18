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
    public class AdminService : IAdminService
    {
        private readonly IBaseRepo<Admin> _adminRepo;
        public AdminService(IBaseRepo<Admin> adminRepo) 
        {
            _adminRepo = adminRepo;
        }
        public Task<bool> CreateAdminAsync(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAdminAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin?> GetAdminByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Admin?>> GetAllAdminAsync()
        {
            return await _adminRepo.GetAllAsync();
        }

        public Task<bool> UpdateAdminAsync(Admin admin)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsAdminIdUniqueAsync(string userId)
        {
            // Query the database to check if a patient with the same ID exists
            var admins = await _adminRepo.GetAllAsync();

            return !admins.Any(p => p.ID == userId);
        }

    }
}
