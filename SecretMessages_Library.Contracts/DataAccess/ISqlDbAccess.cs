using System.Collections.Generic;

namespace SecretMessages_Library.Contracts.DataAccess
{
    public interface ISqlDbAccess
    {
        List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionStringName);
        void SaveData<U>(string sqlStatement, U parameters, string connectionStringName);
    }
}