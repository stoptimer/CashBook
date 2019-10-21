using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashBook.Domain.Entity;

namespace CashBook.Domain.Repository
{
    public interface IExpenseRecordRepository:IRepository<ExpenseRecord>
    {
        Task<IEnumerable<ExpenseRecord>> GetExpenseRecordsByRangeTime(DateTime start, DateTime end);
    }
}
