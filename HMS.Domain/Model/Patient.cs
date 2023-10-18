using HMS.Domain.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Patient : BaseModel
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailID { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        public Role UserRole { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
        public ICollection<Bill>? Bills { get; set; }

        /*  public Patient(  string firstName, string lastName, DateTime? dob, string gender, string bloodGroup, string emailId, string address, string mobileNo)
          {
              FirstName = firstName;
              LastName = lastName;
              DOB = dob;
              Gender = gender;
              BloodGroup = bloodGroup;
              EmailID = emailId;
              Address = address;
              MobileNo = mobileNo;

              Appointments = new List<Appointment>();
              Prescriptions = new List<Prescription>();
              Bills = new List<Bill>();
          }*/
        public Patient()
        {
            Appointments = new List<Appointment>();
            Prescriptions = new List<Prescription>();
            Bills = new List<Bill>();

            ID = GenerateID("PT-");
        }
       
        public override string ToString()
        {
            return ID; // Return the ID property value as a string
        }
    }
}
