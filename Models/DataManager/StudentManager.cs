using Microsoft.EntityFrameworkCore;

using StudentManagement.Models.Repository;

namespace StudentManagement.Models.DataManager
{
    public class StudentManager : IStudentRepository
    {
        private readonly DBContext _studentcontext;

        public StudentManager(DBContext context)
        {
            _studentcontext = context;
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return _studentcontext.Students.ToList();
        }

        public Students GetStudentById(int id)
        {
            return _studentcontext.Students.FirstOrDefault(s => s.SId == id);
        }

        public void AddStudent(Students student)
        {
            _studentcontext.Students.Add(student);
            _studentcontext.SaveChanges();
        }

        public void UpdateStudent(Students student)
        {
            _studentcontext.Students.Update(student);
            _studentcontext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            _studentcontext.Students.Remove(student);
            _studentcontext.SaveChanges();
        }

    }
}
