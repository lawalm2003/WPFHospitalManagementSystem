using HMS.Domain.Const;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Admin : BaseModel
    {                       
        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime? DOB { get; set; }

        [Required]
        public string? Gender { get; set; }

        [EmailAddress]
        [Required]
        public string? EmailID { get; set; }

        [Required]
        public string? MobileNo { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Address { get; set; }
        public Role UserRole { get; set; }

        public ICollection<Bill>? Bills { get; set; }

        /* public Admin( string name, DateTime? dob, string gender, string emailID, string mobileNo, string address)
         {            
             Name = name;
             DOB = dob;
             Gender = gender;
             EmailID = emailID;
             MobileNo = mobileNo;
             Address = address;

             // Initialize the Bills collection if needed
             Bills = new List<Bill>();
         } */
        public Admin()
        {
            Bills = new List<Bill>();
        }
       
    }

}
