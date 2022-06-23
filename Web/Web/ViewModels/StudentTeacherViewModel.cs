using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.ViewModels
{
    public class StudentTeacherViewModel
    {
        public Student Student { get; set;  }
        public IEnumerable<Teacher> Teachers { get; set;  }
        public IEnumerable<Student> Students { get; set; }
    }
}
