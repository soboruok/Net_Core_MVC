using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Data.Repositories;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;

        public HomeController(ITeacherRepository teacherRepository,
                                IStudentRepository studentRepository)
        {
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
        }

        

        public IActionResult Index()
        {
            var teachers = _teacherRepository.GetAllTeachers(); 

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Teachers = teachers
            };

            return View(viewModel);
        }

        //role이 Admin인경우만 접근 가능
        [Authorize(Roles = "Admin")]
        public IActionResult Student()
        {
            var students = _studentRepository.GetlAllStudents();

            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };
            return View(viewModel);
        }

        //role이 Admin인경우만 접근 가능
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Student(StudentTeacherViewModel model)
        {
            //student저장
            if (ModelState.IsValid)
            {
                //model 데이타를 Student테이블에 저장
                _studentRepository.AddStudent(model.Student);
                _studentRepository.Save();

                //작성해던 내용이 클리어된다. 
                ModelState.Clear();

            } else
            {
                //에러를 보여준다
            }


            var students = _studentRepository.GetlAllStudents();
            var viewModel = new StudentTeacherViewModel()
            {
                Student = new Student(),
                Students = students
            };

            return View();
        }

        public IActionResult Detail(int id)
        {
            var result = _studentRepository.GetStudent(id);
            return View(result); 
        }



        public IActionResult Privacy()

        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
