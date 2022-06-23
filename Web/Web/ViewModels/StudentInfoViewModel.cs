using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.ViewModels
{
    public class StudentInfoViewModel
    {
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Title is required")]
        public string UserName { get; set; }

        [Display(Name = "UserEmail")]
        [Required(ErrorMessage = "Title is required")]
        public string UserEmail { get; set; }


        [Display(Name = "UserPhone")]
        [Required(ErrorMessage = "Title is required")]
        public string UserPhone { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        public string UserCourse { get; set; }

        [Display(Name = "UserGPA")]
        [Required(ErrorMessage = "Title is required")]
        public string UserGPA { get; set; }

        [Display(Name = "UserUni")]
        [Required(ErrorMessage = "Title is required")]
        public string UserUni { get; set; }

        [Display(Name = "UserCV")]
        public IFormFile UserCVPath { get; set; }

        [Display(Name = "Registered Date")]
        public DateTime Regdate { get; set; }

        
    }
}
