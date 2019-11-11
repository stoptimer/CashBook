using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashBook.Domain.Entity;

namespace CaskBook.Service.IService
{
    public interface IBalanceService
    {
        Task<Balance> GetBalanceById(int id);
        Task<IEnumerable<ExpenseRecord>> GetExpenseRecordsByRangeTime(DateTime start, DateTime end);
        Task<bool> InsertExpenseRecord(ExpenseRecord expenseRecord);

    }
}
