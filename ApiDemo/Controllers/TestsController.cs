using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using DomainServices.Abstractions;
using DomainServices.ApiModels;
using Microsoft.AspNetCore.Http.Extensions;
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
        public async Task<ActionResult<TestResponseModel>> Get(int id)
        {
            var test = await _testService.GetByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            return test;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddTestModel model)
        {
            try
            {
                var added = await _testService.AddTestAsync(model);
                return Created(Url.Action("Get", "Tests",new {added.Id},null, Request.Host.ToUriComponent()), added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}