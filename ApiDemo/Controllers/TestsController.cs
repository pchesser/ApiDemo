using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using DomainServices.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Test>> Get(int id)
        {
            var test = await _testService.GetByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task Post([FromBody] Test test)
        {

        }
    }
}