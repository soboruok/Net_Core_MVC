using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Post
    {
        [Display(Name = "ID")]
        [Key]
        public long Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [MinLength(5, ErrorMessage = "Not sufficient Length in Title, Min length is 5")]
        public string title { get; set; }

        [Display(Name = "News")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "News is required")]
        [MinLength(10, ErrorMessage = "Not sufficient Length in News, Min length is 10")]
        public string newsContents { get; set; }

        [Display(Name = "Reported Date")]
        public DateTime publishedOn { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Must have max length=20 and min length=5")]
        public string publishedBy { get; set; }

        /* public List<SelectListItem> listP = new List<SelectListItem>();
         public string gender { get; set; }
         public List<hobbies> hs { get; set; }*/
    }
}
