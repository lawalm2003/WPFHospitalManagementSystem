using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IPrescriptionService
    {
        Task<bool> CreatePrescriptionAsync(Prescription prescription);
        Task<IEnumerable<Doctor>> GetAllPrescriptionAsync();
        Task<Doctor?> GetPrescriptionByIdAsync(string id);
        Task<bool> UpdatePrescriptionAsync(Prescription prescription);
        Task<bool> DeletePrescriptionAsync(string id);
    }
}
