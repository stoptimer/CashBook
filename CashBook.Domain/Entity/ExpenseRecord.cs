using System;
namespace CashBook.Domain.Entity
{
    public class ExpenseRecord
    {
        public ExpenseRecord()
        {
        }
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseTime { get; set; }
        public int UserId { get; set; }
        public int Deleted { get; set; }
    }
}
