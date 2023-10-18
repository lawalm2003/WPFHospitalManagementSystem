using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Prescription : BaseModel
    {

        [Required]
        public string? Medicine { get; set; }

        [Required]
        public string? Remark { get; set; }

        [Required]
        public string? Advice { get; set; }

        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }


       /* public Prescription(string medicine, string remark, string advice, Patient patient, Doctor doctor)
        {
            Medicine = medicine;
            Remark = remark;
            Advice = advice;
            Patient = patient;  
            Doctor = doctor;
        }*/
    }

}
