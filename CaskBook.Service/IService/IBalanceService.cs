using System;
using System.Threading.Tasks;
using CashBook.Domain.Entity;

namespace CaskBook.Service.IService
{
    public interface IBalanceService
    {
        ValueTask<Balance> GetBalanceById(int id);
    }
}
