namespace StudentManagement.Models.Repository
{
    public interface IClassRepository
    {
        Task<Class> GetByIdAsync(int id);
        Task<List<Class>> GetAllAsync();
        Task AddAsync(Class @class);
        Task UpdateAsync(Class @class);
        Task DeleteAsync(Class @class);
    }
}
