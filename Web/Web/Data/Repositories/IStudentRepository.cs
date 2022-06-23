using System.Collections.Generic;
using Web.Models;

namespace Web.Data.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        IEnumerable<Student> GetlAllStudents();
        Student GetStudent(int id);
        void Save();
    }
}