using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class StudentInfoEditModel : StudentInfoViewModel
    {
        public int Eid { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
