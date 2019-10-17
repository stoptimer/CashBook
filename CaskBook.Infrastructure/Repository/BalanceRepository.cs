using System;
using System.Data;
using System.Threading.Tasks;
using CashBook.Domain.Entity;
using CashBook.Domain.Repository;
using CaskBook.Infrastructure.Options;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace CaskBook.Infrastructure.Repository
{
    public class BalanceRepository:IRepository<Balance>
    {
        private readonly IDbConnection _dbConnection;
        private readonly IOptions<DbOption> _option;
        public BalanceRepository(IOptions<DbOption> option)
        {
            _option = option;
        }

        public async ValueTask<bool> DeleteAsync(Balance entity)
        {
            using (var db = new MySqlConnection(_option.Value.ConnectionStr))
            {
                db.Open();
               var res= await db.ExecuteAsync("delete from ");
                if (res > 0)
                    return true;
                else
                    return false;
            }
        }

        public async ValueTask<Balance> GetByIdAsync(int id)
        {
            using(var db = new MySqlConnection(_option.Value.ConnectionStr))
            {
                db.Open();
                return await db.QueryFirstAsync<Balance>("select * from Balance where Id =@Id", new { Id = id });
            }
        }

        public ValueTask<int> SaveAsync(Balance entity)
        {
            throw new NotImplementedException();
        }
    }
}
