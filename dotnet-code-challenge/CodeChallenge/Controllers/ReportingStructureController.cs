using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reportingstructure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id}", Name = "getReportByEmployeeId")]
        public IActionResult GetReportById(string id)
        {
            _logger.LogDebug($"Received get request for direct report regarding '{id}'");

            var directReport = _employeeService.GetReportingStructureById(id);

            if (directReport == null)
                return NotFound();

            return Ok(directReport);
        }
    }
}

