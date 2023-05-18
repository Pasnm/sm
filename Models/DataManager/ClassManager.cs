using Microsoft.EntityFrameworkCore;

using StudentManagement.Models.Repository;

namespace StudentManagement.Models.DataManager
{
    public class ClassManager : IClassRepository
    {
        private readonly DBContext _context;

        public ClassManager(DBContext context)
        {
            _context = context;
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<List<Class>> GetAllAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task AddAsync(Class @class)
        {
            await _context.Classes.AddAsync(@class);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Class @class)
        {
            _context.Classes.Update(@class);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Class @class)
        {
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
        }

    }
}
