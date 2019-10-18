using System;
using System.Threading.Tasks;
using CashBook.Domain.Entity;
using CashBook.Domain.Repository;
using CaskBook.Service.IService;

namespace CaskBook.Service.Service
{
    public class BalanceService : IBalanceService
    {
        private readonly IRepository<Balance> _balanceRepository;
        public BalanceService(IRepository<Balance> balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }

        public async Task<Balance> GetBalanceById(int id)
        {
            return await _balanceRepository.GetByIdAsync(id);
        }
    }
}
