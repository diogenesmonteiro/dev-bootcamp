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
    public class SubjectsController : ControllerBase
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public SubjectsController(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Subjects.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var subject = await _dbContext.Subjects.FindAsync(id);
            if (subject == null)
                return NotFound("No record found with provided ID");

            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Subject subject)
        {
            await _dbContext.Subjects.AddAsync(subject);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Subject newSubject)
        {
            var subject = await _dbContext.Subjects.FindAsync(id);
            if (subject == null)
                return NotFound("No record found with provided ID");

            subject.Name = newSubject.Name;
            subject.Description = newSubject.Description;
            await _dbContext.SaveChangesAsync();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var subject = await _dbContext.Subjects.FindAsync(id);
            if (subject == null)
                return NotFound("No record found with provided ID");

            _dbContext.Subjects.Remove(subject);
            await _dbContext.SaveChangesAsync();
            return Ok("Record deleted successfully");
        }
    }
}
