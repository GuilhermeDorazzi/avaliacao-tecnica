using MySql.Data.MySqlClient;

namespace Citel.Data.Repositories.UoW
{
    public interface IDbConnectionFactory
    {
        MySqlConnection CreateMySqlDbConnection(DatabaseConnectionName connectionName);
    }
}
