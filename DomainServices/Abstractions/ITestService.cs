using System.Threading.Tasks;
using Data;

namespace DomainServices.Abstractions
{
    public interface ITestService
    {
        Task<Test> GetByIdAsync(int id);
        Task AddTestAsync(Test test);
    }
}
