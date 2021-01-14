using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interface;
using CleanArchitecture.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    //[ApiVersion("1.0")]
    [Route("/api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository _repository;
        public EmployeeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await _repository.GetAllEmployee());
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee([FromQuery] int id)
        {
            return Ok(await _repository.GetEmployee(id));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeReturnDto employee)
        {
            return Ok(await _repository.AddEmployee(employee));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeReturnDto employee)
        {
            return Ok(await _repository.UpdateEmployee(employee));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmployee([FromQuery] int id)
        {
            return Ok(await _repository.DeleteEmployee(id));
        }
    }
}