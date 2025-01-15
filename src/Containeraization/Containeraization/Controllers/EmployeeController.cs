using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Containeraization
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompanyService _companyService;

        public EmployeeController(IEmployeeService employeeService, ICompanyService companyService)
        {
            this._employeeService = employeeService;
            this._companyService = companyService;
        }

        [HttpPost]
        [Route("save")]
        public IActionResult Post(EmployeeInformation employeeInformation)
        {
            try
            {
                var employee = new Employee();
                employee.Name = employeeInformation.Name;
                employee.Company = this._companyService.Get(Convert.ToInt32(employeeInformation.CompanyId));
                this._employeeService.Create(employee);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;

            }



        }

        [HttpGet]
        [Route("getemployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var companies = this._employeeService.GetAllEmployees();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "");
            }
        }
    }

    public class EmployeeInformation
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string CompanyId { get; set; }
    }
}
