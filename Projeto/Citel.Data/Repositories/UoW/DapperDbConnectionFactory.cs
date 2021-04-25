using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Citel.Data.Repositories.UoW
{
    public class DapperDbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<DatabaseConnectionName, string> _connectionDict;

        public DapperDbConnectionFactory(IDictionary<DatabaseConnectionName, string> connectionDict)
        {
            _connectionDict = connectionDict;
        }

        private string GetConnectionString(DatabaseConnectionName connectionName)
        {
            if (_connectionDict.TryGetValue(connectionName, out string connectionString))
                return connectionString;

            throw new ArgumentNullException();
        }

        public MySqlConnection CreateMySqlDbConnection(DatabaseConnectionName connectionName)
        {
            var connectionString = GetConnectionString(connectionName);
            return new MySqlConnection(connectionString);
        }
    }
}
