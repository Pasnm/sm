namespace StudentManagement.Models.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Students> GetAllStudents();
        Students GetStudentById(int id);
        void AddStudent(Students student);
        void UpdateStudent(Students student);
        void DeleteStudent(int id);
    }
}
