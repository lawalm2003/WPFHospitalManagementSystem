using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.App.IServices
{
    public interface IAppointmentService
    {
        Task<bool> CreateAppointmentAsync(Appointment appointment);
        Task<IEnumerable<Doctor>> GetAllAppointmentsAsync();
        Task<Doctor?> GetAppointmentByIdAsync(string id);
        Task<bool> UpdateAppointmentAsync(Appointment appointment);
        Task<bool> DeleteAppointmentAsync(string id);
    }
}
