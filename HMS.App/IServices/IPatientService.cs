using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IPatientService
    {
        Task<bool> CreatePatientAsync(Patient patient);
        Task<IEnumerable<Patient?>> GetAllPatientsAsync();
        Task<Patient?> GetPatientByIdAsync(string id);
        Task<bool> UpdatePatientAsync(Patient patient);
        Task<bool> DeletePatientAsync(string id);
        Task<bool> IsPatientIdUniqueAsync(string userId);
    }
}
