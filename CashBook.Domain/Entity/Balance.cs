using System;
namespace CashBook.Domain.Entity
{
    /// <summary>
    /// 余额
    /// </summary>
    public class Balance
    {
        public Balance()
        {

        }
        public int Id { get; set; }
        public decimal TotalBalance { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
