using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class User : BaseModel
    {
        [Required]
        [StringLength(9)]
        public string UserId { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
