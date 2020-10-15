using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using WebApplication1.BusinessLogic.Interface;

namespace WebApplication1.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager employeeManager;

        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }


        [HttpGet]
        [Route("api/[controller]/GetEmployeeDetails/{employeeId}")]
        public IActionResult Get(int employeeId)
        {
            var result = employeeManager.GetEmployeeDetails(employeeId);
            if(result.EmployeeId==0)
            {
                return NotFound("employee NotFound");
            };
            return Ok(result);
        }


        [HttpPost]
        [Route("api/[controller]/AddEmployee")]
        public IActionResult CreateEmployee(EmployeeDetailsModel employeeDetails)
        {
            var result = employeeManager.AddEmployee(employeeDetails);
            return CreatedAtAction(null, result);
        }


        [HttpPut]
        [Route("api/[controller]/UpdateEmployee")]
        public IActionResult UpdateEmployeeDetails(EmployeeDetailsUpdateModel model)
        {
            var result = employeeManager.UpdateEmployee(model);
            return NoContent();
        }


        [HttpDelete]
        [Route("api/[controller]/DeleteEmployee/{employeeId}/{updatedBy}")]
        public IActionResult DeleteEmployee(int employeeId, int updatedBy)
        {
            var result = employeeManager.DeleteEmployee(employeeId, updatedBy);
            return NoContent();
        }
    }
}
