using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public EmployeeController()
        {

        }

        [HttpPost]
        [Route("save")]
        public IActionResult Save()
        {
            return StatusCode(500, "");
        }
    }

    public class Content
    {
        public string Value { get; set; }
    }
}
