using EmpAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var Employee = await _context.Employees.FindAsync(id);
            if (Employee == null)
                return BadRequest("Employee not found.");
            return Ok(Employee);
        }

        [Route("GetAllDepartmentNames")]
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllDepartments()
        {
            return Ok(await _context.Departments.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee Employee)
        {
            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            var dbEmployee = await _context.Employees.FindAsync(request.EmployeeId);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            dbEmployee.EmployeeName = request.EmployeeName;
            dbEmployee.EmployeeGender = request.EmployeeGender;
            dbEmployee.EmployeeMobile = request.EmployeeMobile;
            dbEmployee.EmployeeDOB = request.EmployeeDOB;
            dbEmployee.Department = request.Department;
            dbEmployee.DateOfJoining = request.DateOfJoining;
           


            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var dbEmployee = await _context.Employees.FindAsync(id);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }






    }
}