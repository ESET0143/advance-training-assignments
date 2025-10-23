using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

namespace StudentApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }
        /*// GET: api/students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound();

            return student;
        }*/
        /*
        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher(Teacher Teacher)
        {
            _context.Teachers.Add(Teacher);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Teacher), new { id = student.Id }, student);
        }*/
    }
}
