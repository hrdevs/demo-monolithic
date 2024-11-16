using demo_monolithic.Models;
using demo_monolithic.Models.Dtos;
using demo_monolithic.Services;
using Microsoft.AspNetCore.Mvc;

namespace demo_monolithic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("/api/employees")]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employees = _employeeService.GetAll();

            return Ok(employees);
        }

        [HttpGet("{employeeId:int}")]
        public ActionResult<Employee> GetById(int employeeId)
        {
            var employee = _employeeService.GetById(employeeId);
            if (employee == null) return NotFound("Employee not found.");

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody]EmployeeDto employeeDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeExists = await _employeeService.EmployeeExistsAsync(employeeDto.FirstName, employeeDto.LastName);
            if (employeeExists)
            {
                return Conflict("Record already exists.");
            }

            var newEmployee = await _employeeService.Create(employeeDto);

            // Use CreatedAtAction to return the URI of the new employee
            return CreatedAtAction(nameof(GetById), new { employeeId = newEmployee.Id }, newEmployee);
        }

        [HttpPut("{employeeId:int}")]
        public async Task<ActionResult> Update(int employeeId, EmployeeDto employeeDto)
        {
            var employee = _employeeService.GetById(employeeId);
            if (employee == null) return NotFound("Employee not found.");

            var employeeExists = await _employeeService.EmployeeExistsAsync(employeeDto.FirstName, employeeDto.LastName);
            if (employeeExists)
            {
                return Conflict("Record already exists.");
            }

            await _employeeService.Update(employeeId, employeeDto);

            return Ok("Employee updated successfully.");
        }

        [HttpDelete("{employeeId:int}")]
        public async Task<ActionResult> Delete(int employeeId)
        {
            var employee = _employeeService.GetById(employeeId);
            if (employee == null) return NotFound("Employee not found.");

            await _employeeService.Remove(employeeId);

            return Ok("Employee deleted successfully.");
        }
    }
}
