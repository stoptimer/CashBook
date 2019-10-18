using System;
using System.Threading.Tasks;
using CashBook.Domain.Entity;
using CashBook.Domain.Repository;
using CaskBook.Infrastructure.Repository;
using CaskBook.Service.IService;
using CaskBook.Service.Service;
using Moq;
using Xunit;

namespace CashBook.UnitTests
{
    public class BalanceRepositoryTest
    {
        private readonly Mock<IRepository<Balance>> _balanceRepository;
        private IBalanceService _balanceService;
        public BalanceRepositoryTest()
        {
            _balanceRepository = new Mock<IRepository<Balance>>();
        }
        [Fact]
        public async Task Get_Balance_By_UserId_ReturnBalance()
        {
            var expected = new Balance() { Id = 1, TotalBalance = 299 };
            var balance = GetFakeBalance(1, 299, 1);
            _balanceRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(balance));

            _balanceService = new BalanceService(_balanceRepository.Object);
            var actual = await _balanceService.GetBalanceById(expected.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.TotalBalance, actual.TotalBalance);
        }

        private Balance GetFakeBalance(int id, decimal totalBalance, int userId)
        {
            return new Balance()
            {
                Id = id,
                TotalBalance = totalBalance,
                UserId = userId
            };
        }
    }
}
