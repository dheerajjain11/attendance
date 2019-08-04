using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Services; 

namespace EmployeeMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpPost("create")]
        public IActionResult Post(string employeeName)
        { 
            long employeeId = employeeService.CreateEmployee(employeeName);
            return Ok(employeeId);
        }  

        [HttpPut("employee/{id}/update")]
        public IActionResult UpdateEmployee(long id, [FromBody] EmployeeUpdateDTO employeeUpdateDTO)
        {
            employeeService.UpdateEmployee(id, employeeUpdateDTO);
            return Ok();
        }
    }
}
