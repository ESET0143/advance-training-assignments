//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using StudentApi.Data;
//using StudentApi.Models;

//namespace StudentApi.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class StudentsController : ControllerBase
//    {
//        private readonly AppDbContext _context;

//        public StudentsController(AppDbContext context)
//        {
//            _context = context;
//        }



//        // GET: api/students
//        /* [HttpGet]
//         public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
//         {
//             return await _context.Students.ToListAsync();
//         }*/
//        //----------------GET ALL  LINQ ------------------------
//        [HttpGet]
//        public async Task<ActionResult<List<Student>>> GetStudents()
//        {
//            var query = from s in _context.Students
//                        select s;
//            var students = await query.ToListAsync();
//            return students;
//        } 
//        //------------------GET BY ID LINQ ---------------
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Student>> GetStudentById(int id)
//        {

//            var query = from s in _context.Students
//                        where s.Id == id
//                        select s;

//            var Student = await query.FirstOrDefaultAsync();


//            if (Student == null)
//                return NotFound($"Teacher with ID {id} not found");

//            return Student;
//        }


//        //---------select students by course namee ------------

//        [HttpGet("bycourse/{name}")]
//        public async Task<ActionResult<List<Student>>> GetByCourseName(string name)
//        {
//            var query = from s in _context.Students
//                        where s.Course.Contains(name)  // LIKE '%name%'
//                        select s;

//            var students = await query.ToListAsync();

//            if (students.Count == 0)
//                return NotFound($"No students found for course '{name}'");

//            return Ok(students);
//        }
//        //-----group students by grouping course name--------------
//        [HttpGet("groupbycourse")]
//        public async Task<ActionResult> GetStudentsByGroupingCourseName()
//        {
//            // Group students by course
//            var query = _context.Students
//                                .GroupBy(s => s.Course)
//                                .Select(g => new
//                                {
//                                    CourseName = g.Key,       // the Course
//                                    Count = g.Count(),        // number of students in that course
//                                    Students = g.ToList()     // list of students in this group
//                                });

//            var groupedStudents = await query.ToListAsync();

//            return Ok(groupedStudents);
//        }
//        //---select ing students by group name ---------
//        [HttpGet("orderbycourse")]
//        public async Task<ActionResult<List<Student>>> GetStudentsOrderedByCourse()
//        {
//            var query = from s in _context.Students
//                        orderby s.Course   // order by course name ascending
//                        select s;

//            var students = await query.ToListAsync();
//            return students;
//        }




//        //------------ADD NEW STUDENT--------

//        [HttpPost]
//        public async Task<IActionResult> AddStudent([FromBody] Student newStudent)
//        {
//            _context.Students.Add(newStudent);
//            await _context.SaveChangesAsync();

//            return Ok();
//        }

//        //-----UPDATING NEW STUDENT-----------

//        // PUT: api/students/1
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateStudent(int id, Student student)
//        {
//            if (id != student.Id)
//                return BadRequest();

//            _context.Entry(student).State = EntityState.Modified;
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }







//        //----DELETING A NEW STUDENT--------------------



//        // DELETE: api/students/1
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteStudent(int id)
//        {
//            var student = await _context.Students.FindAsync(id);
//            if (student == null)
//                return NotFound();

//            _context.Students.Remove(student);
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Repositories;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _repository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found.");
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            await _repository.AddAsync(student);
            return Ok("Student added successfully");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest("ID mismatch.");

            await _repository.UpdateAsync(student);
            return Ok("Student updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok("Student deleted successfully");
        }
    }
}
