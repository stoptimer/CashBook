using System;
using CashBook.Domain.Entity;
using CashBook.Domain.Repository;

namespace CaskBook.Infrastructure.Repository
{
    public class BalanceRepository:IRepository<Balance>
    {
        public BalanceRepository()
        {
        }

        public bool Delete(Balance entity)
        {
            throw new NotImplementedException();
        }

        public Balance GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Balance entity)
        {
            throw new NotImplementedException();
        }
    }
}
