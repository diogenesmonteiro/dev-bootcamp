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
    public class CourseMembershipsController : ControllerBase
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public CourseMembershipsController(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.CourseMemberships.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var courseMembership = await _dbContext.CourseMemberships.FindAsync(id);
            if (courseMembership == null)
                return NotFound("No record found with provided ID");

            return Ok(courseMembership);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseMembership courseMembership)
        {
            await _dbContext.CourseMemberships.AddAsync(courseMembership);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CourseMembership newCourseMembership)
        {
            var courseMembership = await _dbContext.CourseMemberships.FindAsync(id);
            if (courseMembership == null)
                return NotFound("No record found with provided ID");

            courseMembership.StudentId = newCourseMembership.StudentId;
            courseMembership.CourseId = newCourseMembership.CourseId;
            await _dbContext.SaveChangesAsync();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var courseMembership = await _dbContext.CourseMemberships.FindAsync(id);
            if (courseMembership == null)
                return NotFound("No record found with provided ID");

            _dbContext.CourseMemberships.Remove(courseMembership);
            await _dbContext.SaveChangesAsync();
            return Ok("Record deleted successfully");
        }
    }
}
