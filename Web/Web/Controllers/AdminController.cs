using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        private readonly MyAppContext _db;
        private RoleManager<IdentityRole> _roleManager { get; }
        private UserManager<ApplicationUser> _userManager { get; }

        List<string> userList; 

        public AdminController(MyAppContext db, 
                                RoleManager<IdentityRole> roleManager,
                                UserManager<ApplicationUser> userManager)
        {
            this._db = db;
            this._roleManager = roleManager;
            this._userManager = userManager;
            //we are going to fill this userList. 
            userList = new List<string>();
            var users = _userManager.Users;
            foreach (var user in users) userList.Add(user.Email);
        }

        [HttpGet]
        public IActionResult ManageRole()
        {
            ManageRole mrole = new ManageRole();
            FillArray(mrole); 
            return View(mrole); 
        }

        [HttpPost]
        public async Task<IActionResult> ManageRole(ManageRole mrole)
        {
            var role = await _roleManager.FindByIdAsync(mrole.RoleID);
            var user = await _userManager.FindByIdAsync(mrole.UserID);
            

            if (null == role || null == user) return View("Error"); 
            if ( !(await _userManager.IsInRoleAsync(user, role.Name)))
            {
               var result =  await _userManager.AddToRoleAsync(user, role.Name);
            }

            return View("Display", _roleManager.Roles);
        }

        private void FillArray(ManageRole mrole)
        {
            var users = _userManager.Users;
            mrole.UserList = new List<SelectListItem>();
            foreach (var user in users)
            {
                //SelectListItem receives text and value.
                SelectListItem item = new SelectListItem();
                item.Text = user.UserName;
                item.Value = user.Id;
                mrole.UserList.Add(item); 
            }

            var roles = _roleManager.Roles;
            mrole.RoleList = new List<SelectListItem>();
            foreach (var role in roles)
            {
                //SelectListItem receives text and value.
                SelectListItem item = new SelectListItem();
                item.Text = role.Name;
                item.Value = role.Id;
                mrole.RoleList.Add(item);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRole()
        {
            foreach (var email in userList)
            {
                var u = await _userManager.FindByEmailAsync(email);
                var r = await _userManager.GetRolesAsync(u);
            }

            return View();
        }





        [HttpGet]
        public IActionResult CreateRole()
        {
            return View(new CreateRoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //to the initial value { Name = model.RoleName }
                IdentityRole identityrole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityrole);
                if (result.Succeeded) return View("Display", _roleManager.Roles);
                foreach (IdentityError e in result.Errors)
                {
                    ModelState.AddModelError("", e.Description);
                }
            }
            return View("Display", _roleManager.Roles);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            IdentityResult result = await _roleManager.DeleteAsync(role);
            foreach (IdentityError e in result.Errors)
            {
                ModelState.AddModelError("", e.Description);
            }

            return View("Display", _roleManager.Roles);
        }





        public IActionResult Index()
        {
            return View();
        }

        //Searching
        //Student List
        public IActionResult List(string searchStudent)
        {
            var student = from c in _db.StudentInfos
                             select c;

            if (!string.IsNullOrEmpty(searchStudent))
            {
                //student = student.Where(c => c.UserName == searchStudent);
                student = student.Where(c => c.UserName == searchStudent || c.UserCourse == searchStudent);
            }
            return View(student);

            //var list = _db.StudentInfos.ToList();
            //return View(list);
        }
        
        //Advanced Search
        public IActionResult List2(string UserName, string UserCourse)
        {
            var student = from c in _db.StudentInfos
                          select c;
           
            if (!string.IsNullOrEmpty(UserName))
            {
                student = student.Where(c => c.UserName.Contains(UserName));
                
            }

            if (!string.IsNullOrEmpty(UserCourse))
            {
                student = student.Where(c => c.UserCourse == UserCourse);
            }

            return View(student);

            //var list = _db.StudentInfos.ToList();
            //return View(list);
        }

        
        //UserName UserCourse
        //Sorting
        public IActionResult List3(string UserName, string sortOrder)
        {
            //if sortOrder is Null or Empty, descending by UserName_desc 
            //If sortOrder is UserCourse, descending by user course.
            //If sortOrder is UserGPA, descending by GPA course.
            ViewBag.UserNameSortParm = String.IsNullOrEmpty(sortOrder) ? "UserName_desc" : "";
            ViewBag.UserCourseSortParm = sortOrder == "UserCourse" ? "UserCourse_desc" : "UserCourse";
            ViewBag.UserGPASortParm = sortOrder == "UserGPA" ? "UserGPA_desc" : "UserGPA";

            //select * from StudentInfos
            var student = from c in _db.StudentInfos
                            select c;

            //If there is UserName then, where statement. 
            if (!string.IsNullOrEmpty(UserName))
            {
                student = student.Where(c => c.UserName.Contains(UserName));

            }

            //use switch statement for sorting by the selected field name
            switch (sortOrder)
            {
                case "UserName_desc":
                    student = student.OrderByDescending(c => c.UserName);
                    break;
                case "UserCourse":
                    student = student.OrderBy(c => c.UserCourse);
                    break;
                case "UserCourse_desc":
                    student = student.OrderByDescending(c => c.UserCourse);
                    break;
                case "UserGPA":
                    student = student.OrderBy(c => c.UserGPA);
                    break;
                case "UserGPA_desc":
                    student = student.OrderByDescending(c => c.UserGPA);
                    break;
            }

            return View(student);

            //var list = _db.StudentInfos.ToList();
            //return View(list);
        }


        //View Page an applicant selected by admin
        public IActionResult Detail(int ID)
        {
            /*세션아이디체크
           if (HttpContext.Session.GetString("userid") == null)
           {
               return RedirectToAction("Login", "Account");
           }
           */

            //It brings the contents of only the selected ID.
            var detailID = _db.StudentInfos.FirstOrDefault(n => n.Id.Equals(ID));
            return View(detailID);
        }

        //Sending Email
        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(SendEmail sendmail)
        {
            //checking validation. 
            if (!ModelState.IsValid) return View(); 
            
            try {

                //using MailMessage Class. MailMessage(from, to). 
                //we will get Name(to), subject, message
                MailMessage mail = new MailMessage("smartlittlepuppy@gmail.com", sendmail.Name);
                mail.Subject = sendmail.Subject;
                mail.Body = sendmail.Message;
                mail.IsBodyHtml = false;

                //using SmtpClient Class.
                //create SMTP instant 
                //configure Host, Port and EnableSsl 
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587; // this is default port number. 
                smtpClient.EnableSsl = false;

                ////using NetworkCredential Class.
                //Create Network Credential
                NetworkCredential networkCredential = new NetworkCredential("smartlittlepuppy@gmail.com", "123456");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Send(mail); 
                ViewBag.Message = "Mail has Sent";

                return View();

            }
            catch (Exception ex)
            {
                //If any error occured, it will show.
                ViewBag.Message = ex.Message.ToString(); 
            }

            return View();
        }
    }
}
