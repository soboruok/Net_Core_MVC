using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class ManageRole
    {
        //ApplicationUser (User Class), ApplicationRole(Role Class) Make it together.  
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public List<SelectListItem> UserList { get; set;  }
        public List<SelectListItem> RoleList { get; set; }
    }
}
