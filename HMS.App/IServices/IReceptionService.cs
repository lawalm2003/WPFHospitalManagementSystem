using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IReceptionService 
    {
        Task<bool> CreateReceptionAsync(Receptionist receptionist);
        Task<IEnumerable<Receptionist>> GetAllReceptionsAsync();
        Task<Receptionist?> GetReceptionByIdAsync(string id);
        Task<bool> UpdateReceptionAsync(Receptionist receptionist);
        Task<bool> DeleteReceptionAsync(string id);
        Task<bool> IsReceptionistIdUniqueAsync(string userId);
    }
}
