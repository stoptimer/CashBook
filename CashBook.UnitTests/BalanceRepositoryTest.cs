using System;
using CashBook.Domain.Entity;
using CaskBook.Infrastructure.Repository;
using Moq;
using Xunit;

namespace CashBook.UnitTests
{
    public class BalanceRepositoryTest
    {
        private BalanceRepository _balanceRepository;
        public BalanceRepositoryTest()
        {
            _balanceRepository = new BalanceRepository();
        }
        [Fact]
        public void Get_Balance_By_UserId_ReturnBalance()
        {
            var expected = new Balance() { Id=1,TotalBalance=100};

            var actual = _balanceRepository.GetById(expected.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.TotalBalance, actual.UserId);
        }
    }
}
