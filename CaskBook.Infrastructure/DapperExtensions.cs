using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CaskBook.Infrastructure
{
    public class DapperExtensions
    {
        #region Constant
        private const string INSERT_QUERY = "INSERT INTO {0}({1})  VALUES(@{2}); SELECT LAST_INSERT_ID();";
        private const string INSERT_BULK_QUERY = "INSERT INTO {0}({1}) VALUES ({2})\r\n";
        private const string UPDATE_QUERY = "UPDATE {0} SET {1} WHERE Id = @Id";
        private const string UPDATE_BULK_QUERY = "UPDATE {0} SET {1} WHERE Id = @Id\r\n";
        private const string DELETE_QUERY = "DELETE FROM {0} WHERE Id = @Id";
        private const string DELETE_BULK_QUERY = "DELETE FROM {0} WHERE Id IN(@Ids)";
        private const string SELECT_QUERY = "SELECT\r\n {1} FROM {0}";
        private const string SELECT_FIRST_QUERY = "SELECT TOP(1)\r\n{1} FROM {0}";
        #endregion

        public static string InsertQuery(string tableName, object entity)
        {
            IEnumerable<string> columns = GetColumnsWithoutIdentity(entity.GetType());

            return string.Format(INSERT_QUERY,
                                 tableName,
                                 string.Join(", ", columns.Select(p => string.Format("{0}", p))),
                                 string.Join(", @", columns));
        }

        public static string UpdateQuery(string tableName, object entity)
        {
            IEnumerable<string> columns = GetColumnsWithoutIdentity(entity.GetType());
            string formattedColumns = string.Join(", ", columns.Select(p => string.Format("{0} = @{0}", p)));

            return string.Format(UPDATE_QUERY,
                                 tableName,
                                 formattedColumns);
        }
        public static string DeleteQuery(string tableName)
        {
            return string.Format(DELETE_QUERY,
                                 tableName);
        }
        protected static IEnumerable<string> GetColumns(Type entityType)
        {
            PropertyInfo[] props = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return props.Select(p => p.Name);
        }
        protected static IEnumerable<string> GetColumnsWithoutIdentity(Type entityType)
        {
            PropertyInfo[] props = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return props.Where(p => p.Name != "Id").Select(p => p.Name);
        }
    }
}
