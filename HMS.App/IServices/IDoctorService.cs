using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IDoctorService
    {
        Task<bool> CreateDoctorAsync(Doctor doctor);
        Task<IEnumerable<Doctor?>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(string id);
        Task<bool> UpdateDoctorAsync(Doctor doctor);
        Task<bool> DeleteDoctorAsync(string id);
        Task<bool> IsDoctorIdUniqueAsync(string userId);
    }

}
