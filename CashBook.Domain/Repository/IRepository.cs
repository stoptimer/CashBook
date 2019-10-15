using System;
namespace CashBook.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        int Save(T entity);
        T GetById(int id);
        bool Delete(T entity);
    }
}
