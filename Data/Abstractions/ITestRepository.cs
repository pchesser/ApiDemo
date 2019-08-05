using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstractions
{
    public interface ITestRepository
    {
        Task<Test> GetByIdAsync(int id);
    }
}
