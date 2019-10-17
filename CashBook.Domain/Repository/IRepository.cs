using System;
using System.Threading.Tasks;

namespace CashBook.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        ValueTask<int> SaveAsync(T entity);
        ValueTask<T> GetByIdAsync(int id);
        ValueTask<bool> DeleteAsync(T entity);
    }
}
