using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly DBContext _context;

        public LecturersController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Lecturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lecturer>>> GetLecturers()
        {
          if (_context.Lecturers == null)
          {
              return NotFound();
          }
            return await _context.Lecturers.ToListAsync();
        }

        // GET: api/Lecturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lecturer>> GetLecturer(long id)
        {
          if (_context.Lecturers == null)
          {
              return NotFound();
          }
            var lecturer = await _context.Lecturers.FindAsync(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            return lecturer;
        }

        // PUT: api/Lecturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecturer(long id, Lecturer lecturer)
        {
            if (id != lecturer.LId)
            {
                return BadRequest();
            }

            _context.Entry(lecturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Lecturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lecturer>> PostLecturer(Lecturer lecturer)
        {
          if (_context.Lecturers == null)
          {
              return Problem("Entity set 'DBContext.Lecturers'  is null.");
          }
            _context.Lecturers.Add(lecturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLecturer", new { id = lecturer.LId }, lecturer);
        }

        // DELETE: api/Lecturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer(long id)
        {
            if (_context.Lecturers == null)
            {
                return NotFound();
            }
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LecturerExists(long id)
        {
            return (_context.Lecturers?.Any(e => e.LId == id)).GetValueOrDefault();
        }
    }
}
