using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class SendEmail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } //FROm
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
