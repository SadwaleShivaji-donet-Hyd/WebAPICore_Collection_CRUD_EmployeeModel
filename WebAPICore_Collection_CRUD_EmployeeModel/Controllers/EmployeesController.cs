using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPICore_Collection_CRUD_EmployeeModel.Models;
using WebAPICore_Collection_CRUD_EmployeeModel.Repository;

namespace WebAPICore_Collection_CRUD_EmployeeModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        public EmployeesController(IEmployeeRepository repo)
        {
            _repo=repo;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_repo.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeesById([FromRoute] int id)
        {
            var employee=_repo.GetEmployeeById(id);
            if(employee==null)
            {
                return BadRequest("Employee Id doesnt exists ! Try with Correct Id");
            }
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmp([FromRoute] int id)
        {

            if (!_repo.Exists(id))
                return NotFound();

            _repo.DeleteEmployee(id);
            return NoContent();
        }

        [HttpPost]

        public IActionResult Create([FromBody] Employee employee)
        {
            _repo.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeesById), new { id = employee.Id }, employee);
        }
        [HttpGet("department/{Dept}")]
        public IActionResult GetByEmail(string Dept)
        {
            var employees = _repo.GetEmployeesByDept(Dept);
            if (employees == null || !employees.Any())
            {
                return NotFound("No employees found in the specified department.");
            }
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("Id mismatch");

            if (!_repo.Exists(id))
                return NotFound();

            _repo.UpdateEmployee(employee);
            return NoContent();
        }
        [HttpPatch("{id}/email")]
        public IActionResult UpdateEmail(int id, [FromBody] string email)
        {
            if (!_repo.Exists(id))
                return NotFound();
            _repo.UpdateEmployeeEmail(id, email);
            return NoContent();
        }
    }
}
