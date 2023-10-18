using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Domain.Model
{
    public class BaseModel
    {
        [Key]
        public string ID { get; set; }

        public static string GenerateID(string prefix)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var id = new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)])
              .ToArray());

            return prefix + id;
        }
    }
}
