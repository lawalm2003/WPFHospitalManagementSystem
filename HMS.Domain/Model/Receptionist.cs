using HMS.Domain.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Receptionist : BaseModel
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
        public string? EmailID { get; set; }
        [Required]
        public string? MobileNo { get; set; }
        [Required]
        public string? Address { get; set; }
        public Role UserRole { get; set; }

        public ICollection<Bill>? Bills { get; set; }

        /* public Receptionist(  string firstName, string lastName, DateTime? dob, string gender, string emailID, string mobileNo, string address)
         {
             FirstName = firstName;
             LastName = lastName;
             DOB = dob;
             Gender = gender;
             EmailID = emailID;
             MobileNo = mobileNo;
             Address = address;

             // Initialize the Bills collection if needed
             Bills = new List<Bill>();
         }
         */
        public Receptionist()
        {
            Bills = new List<Bill>();
        }
    }

}
