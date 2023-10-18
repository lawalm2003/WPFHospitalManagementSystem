using HMS.Domain.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Doctor : BaseModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
       
        [Required]
        public string? Specialization { get; set; }

        [Required]
        public string? MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public Role UserRole { get; set; }


        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }

        /* public Doctor(  string? firstName, string? lastName, DateTime? dateOfBirth,
             string? gender, string? specialization, string? mobileNo, string? email)
         {
             FirstName = firstName;
             LastName = lastName;
             DateOfBirth = dateOfBirth;
             Gender = gender;
             Specialization = specialization;
             MobileNo = mobileNo;
             Email = email;

             // Initialize the Appointments and Prescriptions collections if needed
             Appointments = new List<Appointment>();
             Prescriptions = new List<Prescription>();
         }
        */
        public Doctor()
        {
            Appointments = new List<Appointment>();
            Prescriptions = new List<Prescription>();

            ID = GenerateID("DR-");
        }
        public override string ToString()
        {
            return ID; // Return the ID property value as a string
        }
    }
}

