using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="This is required Field")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is required Field")]
        public string FullName { get; set;  }

        [Required(ErrorMessage = "This is required Field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password doens't match")]
        public string ConfirmPassword { get; set; }

    }
}
