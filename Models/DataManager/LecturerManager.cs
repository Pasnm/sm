using Microsoft.EntityFrameworkCore;

using StudentManagement.Models.Repository;

namespace StudentManagement.Models.DataManager
{
    public class LecturerManager : ILecturerRepository
    {
        private readonly DBContext _context;

        public LecturerManager(DBContext context)
        {
            _context = context;
        }

        public async Task<Lecturer> GetByIdAsync(long id)
        {
            return await _context.Lecturers.FindAsync(id);
        }

        public async Task<List<Lecturer>> GetAllAsync()
        {
            return await _context.Lecturers.ToListAsync();
        }

        public async Task AddAsync(Lecturer lecturer)
        {
            await _context.Lecturers.AddAsync(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lecturer lecturer)
        {
            _context.Lecturers.Update(lecturer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lecturer lecturer)
        {
            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
        }
    

    }
}
