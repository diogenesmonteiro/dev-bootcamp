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
    public class StudentsController : ControllerBase
    {
        private readonly ApiStudentEnrolmentDbContext _dbContext;

        public StudentsController(ApiStudentEnrolmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
                return NotFound("No record found with provided ID");

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student newStudent)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
                return NotFound("No record found with provided ID");

            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            await _dbContext.SaveChangesAsync();
            return Ok("Record updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
                return NotFound("No record found with provided ID");

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return Ok("Record deleted successfully");
        }
    }
}
