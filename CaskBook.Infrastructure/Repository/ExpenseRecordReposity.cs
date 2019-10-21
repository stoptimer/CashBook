using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CashBook.Domain.Entity;
using CashBook.Domain.Repository;
using CaskBook.Infrastructure.Options;
using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace CaskBook.Infrastructure.Repository
{
    public class ExpenseRecordReposity: IExpenseRecordRepository
    {
        private readonly IOptions<DbOption> _option;
        public ExpenseRecordReposity(IOptions<DbOption> option)
        {
            _option = option;
        }
        public async Task<bool> DeleteAsync(ExpenseRecord entity)
        {
            using (var db = new MySqlConnection(_option.Value.ConnectionString))
            {
                db.Open();
                var res = await db.ExecuteAsync("delete from ");
                if (res > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<ExpenseRecord> GetByIdAsync(int id)
        {
            using (var db = new MySqlConnection(_option.Value.ConnectionString))
            {
                db.Open();
                return await db.QueryFirstAsync<ExpenseRecord>("select * from ExpenseRecord where Id =@Id", new { Id = id });
            }
        }

        public async Task<IEnumerable<ExpenseRecord>> GetExpenseRecordsByRangeTime(DateTime start, DateTime end)
        {
            using (var db = new MySqlConnection(_option.Value.ConnectionString))
            {
                db.Open();
                return await db.QueryAsync<ExpenseRecord>("select * from ExpenseRecord where ExpenseTime between @Start and @end", new { Start = start.ToString(),End=end.ToString() });
            }
        }

        public async Task<int> SaveAsync(ExpenseRecord entity)
        {
            string commandText = DapperExtensions.InsertQuery(typeof(ExpenseRecord).Name, entity);
            using (var db = new MySqlConnection(_option.Value.ConnectionString))
            {
                db.Open();
                return await db.ExecuteScalarAsync<int>(commandText, entity, null);
            }
        }
    }
}
