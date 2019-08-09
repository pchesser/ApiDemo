using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Abstractions;

namespace Data
{
    public class TestRepository: ITestRepository
    {
        private readonly ITestContext _context;

        public TestRepository(ITestContext context)
        {
            _context = context;
        }

        public async Task<Test> GetByIdAsync(int id)
        {
            return await _context.Tests.FindAsync(id);
        }

        public async Task<Test> AddTestAsync(Test test)
        {
            try
            {
                await _context.Tests.AddAsync(test);
                await _context.SaveChangesAsync();
                return test;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}
