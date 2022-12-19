using EmpAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            var Department = await _context.Departments.FindAsync(id);
            if (Department == null)
                return BadRequest("Department not found.");
            return Ok(Department);
        }

        [HttpPost]
        public async Task<ActionResult<List<Department>>> AddDepartment(Department Department)
        {
            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Department>>> UpdateDepartment(Department request)
        {
            var dbDepartment = await _context.Departments.FindAsync(request.DepartmentId);
            if (dbDepartment == null)
                return BadRequest("Department not found.");

            dbDepartment.DepartmentName = request.DepartmentName;

            await _context.SaveChangesAsync();

            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            try
            {
                var dbDepartment = await _context.Departments.FindAsync(id);
                if (dbDepartment == null)
                    return BadRequest("Department not found.");

                 _context.Departments.Remove(dbDepartment);
                await _context.SaveChangesAsync();



                return Ok("Success");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }

    }
}

