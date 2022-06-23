using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class StudentInfo
    {
        [Key]
        [Required(ErrorMessage = "required")]
        public int Id { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "UserEmail")]
        public string UserEmail { get; set; }

        [Display(Name = "UserPhone")]
        public string UserPhone { get; set; }

        [Display(Name = "Title")]
        public string UserCourse { get; set; }

        [Display(Name = "UserGPA")]
        public string UserGPA { get; set; }

        [Display(Name = "UserUni")]
        public string UserUni { get; set; }

        [Display(Name = "UserCV")]
        public string UserCV { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Registered Date")]
        public DateTime Regdate { get; set; }
       

    }
}
