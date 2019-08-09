using System.Threading.Tasks;

namespace Data.Abstractions
{
    public interface ITestRepository
    {
        Task<Test> GetByIdAsync(int id);
        Task<Test> AddTestAsync(Test test);
    }
}
