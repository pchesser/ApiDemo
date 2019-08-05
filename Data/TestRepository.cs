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
    }
}
