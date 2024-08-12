using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Containeraization.Controllers
{
    [Route("api/healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheck _healthCheck;
        public HealthCheckController(IHealthCheck healthcheck)
        {
            this._healthCheck = healthcheck;
        }

        [HttpGet("checkconn")]
        public IActionResult IsConnectionAvailable()
        {
            return Ok(this._healthCheck.IsConnectionAvailable());
        }

        
        [HttpGet("getconn")]
        public IActionResult GetConnectionString()
        {
            return Ok(this._healthCheck.GetConnectionString());
        }

        [HttpGet("getenv")]
        public IActionResult GetEnvironment()
        {
            return Ok(this._healthCheck.GetEnvironment());
        }
    }
}
