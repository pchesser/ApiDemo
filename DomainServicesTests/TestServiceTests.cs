using System;
using System.Threading.Tasks;
using Data.Abstractions;
using DomainServices;
using Moq;
using Xunit;

namespace DomainServicesTests
{
    public class TestServiceTests
    {
        [Fact]
        public async Task GetUser_IdLessThan1_Throws()
        {
            var m = new Mock<ITestRepository>();
            var ts = new TestService(m.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await ts.GetByIdAsync(0));
        }
    }
}
