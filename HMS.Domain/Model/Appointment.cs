using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class Appointment : BaseModel
    {
        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public string? P_ID { get; set; }

        [Required]
        public string? D_ID { get; set; }

        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }

       /* public Appointment( DateTime? date, TimeSpan time, string p_ID, string d_ID, Patient patient, Doctor doctor)
        {            
            Date = date;
            Time = time;
            P_ID = p_ID;
            D_ID = d_ID;
            Patient = patient;
            Doctor = doctor;
        }*/

       
    }        

}
