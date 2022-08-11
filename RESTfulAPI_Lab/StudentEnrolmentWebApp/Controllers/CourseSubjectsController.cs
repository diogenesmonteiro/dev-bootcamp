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
    public class CourseSubjectsController : ControllerBase
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public CourseSubjectsController(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.CourseSubjects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var courseSubject = await _dbContext.CourseSubjects.FindAsync(id);
            if (courseSubject == null)
                return NotFound("No record found with provided ID");

            return Ok(courseSubject);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseSubject courseSubject)
        {
            await _dbContext.CourseSubjects.AddAsync(courseSubject);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseSubject newCourseSubject)
        {
            var courseSubject = await _dbContext.CourseSubjects.FindAsync(id);
            if (courseSubject == null)
                return NotFound("No record found with provided ID");

            courseSubject.CourseId = newCourseSubject.CourseId;
            courseSubject.SubjectId = newCourseSubject.SubjectId;
            await _dbContext.SaveChangesAsync();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var courseSubject = await _dbContext.CourseSubjects.FindAsync(id);
            if (courseSubject == null)
                return NotFound("No record found with provided ID");

            _dbContext.CourseSubjects.Remove(courseSubject);
            await _dbContext.SaveChangesAsync();
            return Ok("Record deleted successfully");
        }
    }
}
