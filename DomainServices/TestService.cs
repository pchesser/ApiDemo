using System;
using System.Threading.Tasks;
using Data;
using Data.Abstractions;
using DomainServices.Abstractions;
using DomainServices.ApiModels;

namespace DomainServices
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepo;

        public TestService(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<TestResponseModel> GetByIdAsync(int id)
        {
            if (id < 1)
            {
                throw new InvalidOperationException("id must be greater than 0");
            }
            var test = await _testRepo.GetByIdAsync(id);
            return new TestResponseModel
            {
                Id = test.Id,
                Name = test.Name,
                PhoneNumber = test.PhoneNumber,
                State = test.State
            };
        }

        public Task<Test> AddTestAsync(AddTestModel model)
        {
            if (model.Name == null)
            {
                throw new InvalidOperationException("name cannot be null");
            }

            var test = new Test
            {
                Name = model.Name,
                State = model.State,
                PhoneNumber = model.PhoneNumber,
                Data = "{\"this\":\"is a test\"}"
            };

            var created = _testRepo.AddTestAsync(test);
            return created;
        }
    }
}
