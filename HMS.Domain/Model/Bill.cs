using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Bill : BaseModel
    {        
        public string? BillNo { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        [NotMapped]
        public TimeOnly? Time { get; set; }

        [Required]
        public int Amount { get; set; }

        public Patient? Patient { get; set; }
        public Admin? Admin { get; set; }
        public Receptionist? Receptionist { get; set; }

       /* public Bill(string billNo, DateTime? date, TimeOnly? time, int amount, Patient patient, Admin admin, Receptionist receptionist)
        {
            BillNo = billNo;
            Date = date;
            Time = time;
            Amount = amount;          
            Patient = patient;
            Admin = admin;
            Receptionist = receptionist;

        }*/
    }

}
