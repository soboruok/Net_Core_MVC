using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyAppContext _context;

        public StudentRepository(MyAppContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            //메모리에 student엔티티 추가 할 준비됐다
            _context.Students.Add(student);

        }

        //student엔티티를 데이타베이스에 추가
        public void Save()
        {
            _context.SaveChanges();
        }

        //student를 읽어온다.
        public IEnumerable<Student> GetlAllStudents()
        {
            var result = _context.Students.ToList();
            return result;
        }



        //student열에 매칭하는 id열을 찾아서, 리턴한다
        public Student GetStudent(int id)
        {
            var result = _context.Students.Find(id);
            return result;
        }


    }
}
