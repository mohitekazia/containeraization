using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Containeraization.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            this._companyService = companyService;
        }

        [HttpGet]                                
        public IActionResult GetAllCompanies()
        {
            try
            {
                var companies = this._companyService.GetAllCompanies();
                return Ok(companies);
            }catch(Exception ex)
            {
                return StatusCode(500, "");
            }
        }
    }
}
