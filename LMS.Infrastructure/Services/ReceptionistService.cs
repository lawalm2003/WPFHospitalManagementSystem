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
    public class ReceptionistService : IReceptionService
    {
        private readonly IBaseRepo<Receptionist> _receptionistRepo;

        public ReceptionistService(IBaseRepo<Receptionist> receptionistRepo)
        {
            _receptionistRepo = receptionistRepo;
        }

        public Task<bool> CreateReceptionAsync(Receptionist receptionist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteReceptionAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Receptionist>> GetAllReceptionsAsync()
        {
            return await _receptionistRepo.GetAllAsync();
        }

        public Task<Receptionist?> GetReceptionByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateReceptionAsync(Receptionist receptionist)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsReceptionistIdUniqueAsync(string userId)
        {
            // Query the database to check if a patient with the same ID exists
            var receptionists = await _receptionistRepo.GetAllAsync();

            return !receptionists.Any(p => p.ID == userId);
        }

    }
}
