using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Shared.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;

namespace StudentEnrollment.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly AppDbContext _dbContext;

        public CoursesController(AppDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        public IActionResult  CreateCourse(Course course)
        {

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = course.CourseId }, course);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_dbContext.Courses.Find(id));

        [HttpGet]
        public IActionResult GetAll() => Ok(_dbContext.Courses.ToList());



        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] Course course)
        {
            var record = _dbContext.Courses.Find(id);
            if (record == null) return NotFound();

            record.CourseName = course.CourseName;
            record.CourseCode = course.CourseCode;
            _dbContext.SaveChanges();

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var record = _dbContext.Courses.Find(id);
            if (record == null) return NotFound();

            _dbContext.Courses.Remove(record);
            _dbContext.SaveChanges();
            return NoContent();
        }


    }
}
