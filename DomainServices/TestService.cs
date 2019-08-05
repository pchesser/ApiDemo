using System;
using System.Threading.Tasks;
using Data;
using Data.Abstractions;
using DomainServices.Abstractions;

namespace DomainServices
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepo;

        public TestService(ITestRepository testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await _testRepo.GetByIdAsync(id);
        }

        public async Task AddTestAsync(Test test)
        {
            if (string.IsNullOrWhiteSpace(test.Name))
            {
                throw new InvalidOperationException("Name can not be null");
            }

            if (string.IsNullOrWhiteSpace(test.Data))
            {
                throw new InvalidOperationException("Data can not be null");
            }


        }
    }
}
