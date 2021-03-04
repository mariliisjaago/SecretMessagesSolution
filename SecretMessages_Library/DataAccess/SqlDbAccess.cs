using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SecretMessages_Library.Contracts.DataAccess;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SecretMessages_Library.DataAccess
{
    public class SqlDbAccess : ISqlDbAccess
    {
        private readonly IConfiguration _config;

        public SqlDbAccess(IConfiguration config)
        {
            _config = config;
        }

        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = connection.Query<T>(sqlStatement, parameters).ToList();

                return rows;
            }
        }

        public void SaveData<U>(string sqlStatement, U parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }
    }
}
