namespace StudentManagement.Models.Repository
{
    public interface ILecturerRepository
    {
        Task<Lecturer> GetByIdAsync(long id);
        Task<List<Lecturer>> GetAllAsync();
        Task AddAsync(Lecturer lecturer);
        Task UpdateAsync(Lecturer lecturer);
        Task DeleteAsync(Lecturer lecturer);
    }
}
