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
    public class DoctorService : IDoctorService
    {
        private readonly IBaseRepo<Doctor> _doctorRepo;

        public DoctorService(IBaseRepo<Doctor> doctorRepo)
        {
            _doctorRepo = doctorRepo ?? throw new ArgumentNullException(nameof(doctorRepo));
        }

        public async Task<bool> CreateDoctorAsync(Doctor doctor)
        {
            // Check if a doctor with the same properties already exists in the database
            var existingDoctor = await FindExistingDoctorAsync(doctor);

            if (existingDoctor != null)
            {
                // A doctor with identical properties already exists
                return false;
            }

            // No identical doctor found, proceed with adding the new doctor
            return await _doctorRepo.CreateAsync(doctor);
        }

        private async Task<Doctor?> FindExistingDoctorAsync(Doctor doctor)
        {
            // Query the database to find a doctor with identical properties
            var doctors = await _doctorRepo.GetAllAsync();

            return doctors.FirstOrDefault(d =>
                d.FirstName == doctor.FirstName &&
                d.LastName == doctor.LastName &&
                d.DateOfBirth == doctor.DateOfBirth &&
                d.Gender == doctor.Gender &&
                d.Specialization == doctor.Specialization &&
                d.MobileNo == doctor.MobileNo &&
                d.Email == doctor.Email);
        }


        public async Task<IEnumerable<Doctor?>> GetAllDoctorsAsync()
        {
            return await _doctorRepo.GetAllAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(string id)
        {
            return await _doctorRepo.GetByIdAsync(id);
        }

        public async Task<bool> UpdateDoctorAsync(Doctor doctor)
        {
            return await _doctorRepo.UpdateAsync(doctor);
        }

        public async Task<bool> DeleteDoctorAsync(string id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor != null)
            {
                return await _doctorRepo.DeleteAsync(doctor);
            }
            return false;
        }


        public async Task<bool> IsDoctorIdUniqueAsync(string userId)
        {
            // Query the database to check if a patient with the same ID exists
            var doctors = await _doctorRepo.GetAllAsync();

            return !doctors.Any(p => p.ID == userId);
        }

    }

}
