using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyAppContext _context;

        public TeacherRepository(MyAppContext context)
        {
            _context = context;
        }

        //TeacherList불러오는 함수.
        public IEnumerable<Teacher> GetAllTeachers()
        {
            var result = _context.Teachers.ToList();

            return result;
        }

        //id를 매개변수로 넘겨서 매치하는거 불러오기 
        public Teacher GetTeacher(int id)
        {
            var result = _context.Teachers.Find(id);
            return result;
        }



    }
}
