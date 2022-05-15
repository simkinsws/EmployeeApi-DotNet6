using EmployeeApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private readonly DataBaseContext _db; 

        public EmployeeController(DataBaseContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
         
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> addEmployee(Employee emp)
        {

            _db.Employees.Add(emp);
            await _db.SaveChangesAsync();
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> updateEmployee(Employee emp)
        {
            var empToUpdate = await _db.Employees.FindAsync(emp.Id);
            if(empToUpdate == null)
                 return BadRequest("Hero not found");
            empToUpdate.Salary = emp.Salary;
            empToUpdate.Address = emp.Address;
            empToUpdate.Title = emp.Title;

            await _db.SaveChangesAsync();
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> deleteEmployee(string id)
        {
            var empToDelete = await _db.Employees.FindAsync(id);
            if (empToDelete == null)
                return BadRequest("Employee not found");
            _db.Employees.Remove(empToDelete);
            await _db.SaveChangesAsync();
            return Ok(await _db.Employees.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> getEmployeeById(string id)
        {
            var emp = await _db.Employees.FindAsync(id);
            if(emp == null)
                return NotFound("Employee with Id : " + id + " Was Not Found Or not exist.");
            return Ok(emp);
        }
    }
}
