using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashBook.Domain.Entity;
using CashBook.Domain.Repository;
using CaskBook.Service.IService;

namespace CaskBook.Service.Service
{
    public class BalanceService : IBalanceService
    {
        private readonly IRepository<Balance> _balanceRepository;
        private readonly IExpenseRecordRepository _expenseRecordRepository;
        public BalanceService(IRepository<Balance> balanceRepository, IExpenseRecordRepository expenseRecordRepository)
        {
            _balanceRepository = balanceRepository;
            _expenseRecordRepository = expenseRecordRepository;
        }

        public async Task<Balance> GetBalanceById(int id)
        {
            return await _balanceRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<ExpenseRecord>> GetExpenseRecordsByRangeTime(DateTime start, DateTime end)
        {
            return await _expenseRecordRepository.GetExpenseRecordsByRangeTime(start, end);
        }
        public async Task<bool> InsertExpenseRecord(ExpenseRecord expenseRecord)
        {
            var result = await _expenseRecordRepository.SaveAsync(expenseRecord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
