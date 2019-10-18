using System;
using System.Threading.Tasks;

namespace CashBook.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<int> SaveAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<bool> DeleteAsync(T entity);
    }
}
