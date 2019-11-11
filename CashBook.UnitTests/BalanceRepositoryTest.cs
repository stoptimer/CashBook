using System;
using System.Linq;
using System.Collections.Generic;
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
        private readonly Mock<IExpenseRecordRepository> _expenseRecordRepository;
        private IBalanceService _balanceService;
        public BalanceRepositoryTest()
        {
            _balanceRepository = new Mock<IRepository<Balance>>();
            _expenseRecordRepository = new Mock<IExpenseRecordRepository>();
        }
        [Fact]
        public async Task Get_Balance_By_UserId_ReturnBalance()
        {
            var expected = new Balance() { Id = 1, TotalBalance = 299 };
            var balance = GetFakeBalance(1, 299, 1);
            _balanceRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(balance));

            _balanceService = new BalanceService(_balanceRepository.Object, _expenseRecordRepository.Object);
            var actual = await _balanceService.GetBalanceById(expected.Id);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.TotalBalance, actual.TotalBalance);
        }
        [Fact]
        public async Task Get_ExpenseRecord_By_TimeRange_ReturnExpenseRecords()
        {
            var expenseRecords = new List<ExpenseRecord>();
            expenseRecords.Add(GetFakeExpenseRecord(1, 200, 1, DateTime.Parse("2019-10-19")));
            expenseRecords.Add(GetFakeExpenseRecord(2, 100, 1, DateTime.Parse("2019-10-18")));
            expenseRecords.Add(GetFakeExpenseRecord(3, 500, 1, DateTime.Parse("2019-10-17")));
            _expenseRecordRepository.Setup(x => x.GetExpenseRecordsByRangeTime(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(Task.FromResult(expenseRecords.AsEnumerable()));
            _balanceService = new BalanceService(_balanceRepository.Object, _expenseRecordRepository.Object);
            var actual = await _balanceService.GetExpenseRecordsByRangeTime(DateTime.Parse("2019-10-01"), DateTime.Parse("2019-10-10"));
            Assert.NotNull(actual);
            Assert.All(actual, x => Assert.Equal(1, x.UserId));
        }
        [Fact]
        public async Task Insert_ExpenseRecord()
        {
            var expenseRecord = new ExpenseRecord() {  Amount = 100, Deleted = 0, ExpenseTime = DateTime.Parse("2019-11-10"), UserId = 1 };
            _expenseRecordRepository.Setup(x => x.SaveAsync(It.IsAny<ExpenseRecord>())).Returns(Task.FromResult(1));
            _balanceService = new BalanceService(_balanceRepository.Object, _expenseRecordRepository.Object);
            var actual = await _balanceService.InsertExpenseRecord(expenseRecord);
            Assert.True(actual);
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

        private ExpenseRecord GetFakeExpenseRecord(int id, decimal expenseAmount, int userId, DateTime expenseTime)
        {
            return new ExpenseRecord()
            {
                Id = id,
                Amount = expenseAmount,
                UserId = userId,
                ExpenseTime = expenseTime
            };
        }
    }
}
