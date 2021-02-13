using Dapper;
using Microsoft.Extensions.Configuration;
using SecretMessages_Library.Contracts.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SecretMessages_Library.DataAccess
{
    public class SqliteDbAccess : ISqlDbAccess
    {
        private readonly IConfiguration _config;

        public SqliteDbAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                List<T> data = connection.Query<T>(sqlStatement, parameters).ToList();

                return data;
            }
        }

        public void SaveData<U>(string sqlStatement, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }
    }
}
