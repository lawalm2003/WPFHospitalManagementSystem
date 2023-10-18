using HMS.App.IServices;
using HMS.Domain.IRepositories;
using HMS.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services
{
    public class PatientService : IPatientService
    {
        private readonly IBaseRepo<Patient> _patientRepo;

        public PatientService(IBaseRepo<Patient> patientRepo)
        {
            _patientRepo = patientRepo ?? throw new ArgumentNullException(nameof(patientRepo));
        }



        public async Task<bool> CreatePatientAsync(Patient patient)
        {
            var existingPatient = await FindExistingPatientAsync(patient);

            if (existingPatient != null)
            {
                // A doctor with identical properties already exists
                return false;
            }

            // No identical doctor found, proceed with adding the new doctor
            return await _patientRepo.CreateAsync(patient);
        }


        private async Task<Patient?> FindExistingPatientAsync(Patient patient)
        {
            // Query the database to find a doctor with identical properties
            var patients = await _patientRepo.GetAllAsync();

            return patients.FirstOrDefault(d =>
                d.FirstName == patient.FirstName &&
                d.LastName == patient.LastName &&
                d.DOB == patient.DOB &&
                d.Gender == patient.Gender &&
                d.Address == patient.Address &&
                d.MobileNo == patient.MobileNo &&
                d.EmailID == patient.EmailID);
        }



        public async Task<bool> DeletePatientAsync(string id)
        {
            var patient = await _patientRepo.GetByIdAsync(id);
            if (patient != null)
            {
                return await _patientRepo.DeleteAsync(patient);
            }
            return false;
        }

        public async Task<IEnumerable<Patient?>> GetAllPatientsAsync()
        {
            return await _patientRepo.GetAllAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(string id)
        {
            return await _patientRepo.GetByIdAsync(id);
        }

        public async Task<bool> UpdatePatientAsync(Patient patient)
        {
            return await _patientRepo.UpdateAsync(patient);
        }


        public async Task<bool> IsPatientIdUniqueAsync(string userId)
        {
            // Query the database to check if a patient with the same ID exists
            var patients = await _patientRepo.GetAllAsync();

            return !patients.Any(p => p.ID == userId);
        }

    }
}
