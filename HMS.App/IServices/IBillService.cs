using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IBillService
    {
        Task<bool> CreateBillAsync(Bill bill);
        Task<IEnumerable<Doctor>> GetAllBillsAsync();
        Task<Doctor?> GetBillByIdAsync(string id);
        Task<bool> UpdateBillAsync(Bill bill);
        Task<bool> DeleteBillAsync(string id);
    }
}
