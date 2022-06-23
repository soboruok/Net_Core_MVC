using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using Web.Data;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class InterviewController : Controller
    {
        private readonly MyAppContext _db;
        private readonly IWebHostEnvironment _iWeb;


        //IWebHostEnvironment Dependency injection was done to access the webrootpath.
        public InterviewController(MyAppContext db,
                                   IWebHostEnvironment iWeb)
        {
            _db = db;
            _iWeb = iWeb;
        }

        //About Page
        public IActionResult About()
        {
            ViewBag.title = "About CSIRO";
            return View();
        }

        //Test
        public IActionResult Index()
        {
            //Checking if sessionId exists.
            if (HttpContext.Session.GetString("userid") == null) RedirectToAction("Login", "Account");

            string uid = HttpContext.Session.GetString("UserID");// this is for demo purpose.
            return View();
        }


        //View application form
        [HttpGet]
        public IActionResult Apply()
        {
            ViewBag.title = "Post Your Application!";
            //Checking if sessionId exists.
            if (HttpContext.Session.GetString("userid") == null)
            {
                //RedirectToAction("actionName", "controllerName", model);
                return RedirectToAction("Login", "Account");
            }

            //passed regdate, userEmail for initial value.
            return View(new StudentInfoViewModel() { Regdate = DateTime.Now, UserEmail = HttpContext.Session.GetString("userEmail") });
        }


        //Add Student
        [HttpPost]
        public IActionResult Apply(StudentInfoViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                //GPA 
                //int GPA = Convert.ToInt32(model.UserGPA);
                float GPA = Convert.ToSingle(model.UserGPA);

                // cannot register if the GPA is less than 3.
                if (GPA < 3 )
                {
                    ModelState.AddModelError(string.Empty, "GPA is not enough");
                } 
                else
                {
                    string uniqueFileName = UploadedFile(model); 

                    //Console.WriteLine(uniqueFileName);
                    //Get new student
                    StudentInfo newStudent = new StudentInfo
                    {
                        UserName = model.UserName,
                        UserEmail = model.UserEmail,
                        UserPhone = model.UserPhone,
                        UserCourse = model.UserCourse,
                        UserGPA = model.UserGPA,
                        UserUni = model.UserUni,
                        Regdate = model.Regdate,
                        UserCV = uniqueFileName
                    };

                    _db.StudentInfos.Add(newStudent);

                    //if result is successful.
                    if (_db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index", "Interview");
                    } 
                    else 
                    { 
                    ModelState.AddModelError(string.Empty, "unsuccesfful");
                    }

                }
            }
            return View(model); 
        }

        //Edit Student
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            StudentInfo model = _db.StudentInfos.Find(Id);
            StudentInfoEditModel StudentInfoEditModel = new StudentInfoEditModel
            {
                UserName = model.UserName,
                UserEmail = model.UserEmail,
                UserPhone = model.UserPhone,
                UserCourse = model.UserCourse,
                UserGPA = model.UserGPA,
                UserUni = model.UserUni,
                Regdate = model.Regdate,
                ExistingPhotoPath = model.UserCV
            };
            return View(StudentInfoEditModel);
        }



        //Edit Student
        [HttpPost]
        public IActionResult Edit(StudentInfoEditModel model)
        {
            if (ModelState.IsValid)
            {
                //Put the data transferred from the Edit page into the entity. 
                StudentInfo StudentInfo = _db.StudentInfos.Find(model.Id);
                StudentInfo.UserName = model.UserName;
                StudentInfo.UserEmail = model.UserEmail;
                StudentInfo.UserPhone = model.UserPhone;
                StudentInfo.UserCourse = model.UserCourse;
                StudentInfo.UserGPA = model.UserGPA;
                StudentInfo.UserUni = model.UserUni;
                StudentInfo.Regdate = model.Regdate;
                if(model.UserCVPath != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        //_iWeb.WebRootPath(root location)/upload/fileName
                        string filePath = Path.Combine(_iWeb.WebRootPath, "upload", 
                                                        model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    StudentInfo.UserCV = UploadedFile(model);
                }

                //Update passed data. 
                _db.Entry(StudentInfo).State = EntityState.Modified;
                _db.SaveChanges();

                //When returning to interview/detail, the id value is also returned.
                return RedirectToAction("Detail", "Interview", new { id = StudentInfo.Id } );
            }
            return View(); 
        }


        //file upload function 
        private string UploadedFile(StudentInfoViewModel model)
        {
            string uniqueFileName = null;
           
            if (model.UserCVPath != null)
            {
                //Use Path to combine WebRootPath and the upload folder at the bottom of www.
                string uploadsFolder = Path.Combine(_iWeb.WebRootPath + "/upload");
                //Create a unique name. Guid
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UserCVPath.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                //The uploaded file will be copied to the image folder.
                //To copy the contents of an uploaded file, a new FileStream is required. 
                //Use FileMode.Create to create it on the server.
                model.UserCVPath.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            return uniqueFileName;
        }


        //read
        [HttpGet]
        public IActionResult Detail()
        {
            //Checking if sessionId exists.
            if (HttpContext.Session.GetString("userid") == null)
            {
                return RedirectToAction("Login", "Account");
            } 

            //select * from StudentInfos where UserEmail = 'HttpContext.Session.GetString("userEmail")'
            var userEmail = HttpContext.Session.GetString("userEmail");
            var applicant = _db.StudentInfos.FirstOrDefault(n => n.UserEmail.Equals(userEmail));

            //if applicant is empty, go to interview/apply
            if (applicant == null )
            {
                return RedirectToAction("Apply", "Interview");
            } else
            {
                return View(applicant);
            }

        }


    }
}
