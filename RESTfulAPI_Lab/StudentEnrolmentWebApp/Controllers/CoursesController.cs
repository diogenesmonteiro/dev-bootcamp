using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentEnrolmentWebApp.Data;
using StudentEnrolmentWebApp.Models;

namespace StudentEnrolmentWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public CoursesController(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Courses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null)
                return NotFound("No record found with provided ID");

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Course newCourse)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null)
                return NotFound("No record found with provided ID");

            course.Name = newCourse.Name;
            course.Description = newCourse.Description;
            await _dbContext.SaveChangesAsync();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null)
                return NotFound("No record found with provided ID");

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
            return Ok("Record deleted successfully");
        }
    }
}
