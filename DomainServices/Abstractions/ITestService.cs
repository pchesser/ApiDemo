using System.Threading.Tasks;
using Data;
using DomainServices.ApiModels;

namespace DomainServices.Abstractions
{
    public interface ITestService
    {
        Task<TestResponseModel> GetByIdAsync(int id);
        Task<Test> AddTestAsync(AddTestModel model);
    }
}
