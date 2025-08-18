using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Shared.Models;

namespace StudentEnrollment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost] // matches POST /api/students
        public IActionResult CreateStudent([FromBody] Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudents), new { id = student.StudentId }, student);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudents(int id) => Ok(_context.Students.Find(id));

        [HttpGet]
        public IActionResult GetStudentById() => Ok(_context.Students.ToList());

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var record = _context.Students.Find(id);
            if (record == null) return NotFound();

            record.StudentName = student.StudentName;
            record.StudentSurname = student.StudentSurname;
            record.StudentEmail = student.StudentEmail;
            record.StudentIDNumber = student.StudentIDNumber;
            _context.Students.Add(record);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
