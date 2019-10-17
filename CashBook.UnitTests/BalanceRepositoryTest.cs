using System;
using System.Threading.Tasks;
using CashBook.Domain.Entity;
using CaskBook.Infrastructure.Repository;
using CaskBook.Service.IService;
using CaskBook.Service.Service;
using Moq;
using Xunit;

namespace CashBook.UnitTests
{
    public class BalanceRepositoryTest
    {
        private Mock<BalanceRepository> _balanceRepository;
        private IBalanceService _balanceService;
        public BalanceRepositoryTest()
        {
            _balanceRepository = new Mock<BalanceRepository>();
        }
        [Fact]
        public async Task Get_Balance_By_UserId_ReturnBalance()
        {
            var expected = new Balance() { Id=1,TotalBalance=100};
            _balanceRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Balance(){Id=1,TotalBalance=100 });
            _balanceService = new BalanceService(_balanceRepository.Object);
            var actual = await _balanceService.GetBalanceById(expected.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.TotalBalance, actual.TotalBalance);
        }
    }
}
