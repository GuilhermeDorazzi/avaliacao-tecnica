using Citel.Data.Repositories.UoW;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Citel.Data.Repositories.Base
{
    public partial class MySqlDapperHelper
    {
        #region Propriedades

        public readonly IConfiguration Configuration;

        /// <summary>
        /// A conexao agora é injetada, e deve ser compartilhada entre todas as acoes da instancia atual da API
        /// </summary>
        public MySqlConnection DbConnection { get; private set; }

        #endregion Propriedades

        #region Construtores

        public MySqlDapperHelper(IConfiguration configuration, IDbConnectionFactory dbConnectionFactory)
        {
            Configuration = configuration;
            DbConnection = dbConnectionFactory.CreateMySqlDbConnection(DatabaseConnectionName.MySqlDbConnection);
        }

        #endregion Construtores

        #region Publicos

        #region Transacao

        public MySqlTransaction GetMySqlTransaction()
        {
            if (DbConnection.State == ConnectionState.Closed)
                DbConnection.Open();

            return DbConnection.BeginTransaction();
        }

        #endregion Transacao

        #region Consulta

        /// <summary>
        /// Realiza uma consulta no banco de dados
        /// </summary>
        /// <typeparam name="T">Tipo a ser utilizado na conversao de dados para o retorno</typeparam>
        /// <param name="sql">Sql a ser executado</param>
        /// <param name="param">Parâmetros para a consulta</param>
        /// <returns>Lista contendo o resultado</returns>
        public IEnumerable<T> Query<T>(string sql, object param)
        {
            List<T> resultado;

            var con = DbConnection;

            resultado = con.Query<T>(sql, param).ToList();

            return resultado;
        }

        #endregion Consulta

        #region Dml

        /// <summary>
        /// Realiza a execução de comandos sql como insert, update e delete
        /// </summary>
        /// <param name="sql">Comando a ser executado</param>
        /// <param name="param">Parametros a serem utilizados pelo comando</param>
        /// <returns>Quantidade de registros alterados com o comando</returns>
        public int Execute(string sql, object param)
        {
            int resultado;

            var con = DbConnection;

            resultado = con.Execute(sql, param);

            return resultado;
        }

        /// <summary>
        /// Realiza a execução de comandos sql como insert, update e delete
        /// </summary>
        /// <param name="sql">Comando a ser executado</param>
        /// <param name="param">Parametros a serem utilizados pelo comando</param>
        /// <returns>Quantidade de registros alterados com o comando</returns>
        public int ExecuteInTransaction(string sql, object param, MySqlTransaction mySqlTransaction)
        {
            if (mySqlTransaction == null)
                return -1;

            int resultado;
            var con = mySqlTransaction.Connection;

            resultado = con.Execute(sql, param);
            return resultado;

        }

        #endregion Dml

        #region Utilitarios 

        public virtual long GetGerarCodigo(string Tabela, string Coluna)
        {
            var sql = string.Format("SELECT (MAX({1}) + 1) FROM {0}", Tabela, Coluna);

            long? codigo = Query<long>(sql, null).FirstOrDefault();

            return codigo.GetValueOrDefault(1);
        }

        public DateTime RecuperarDataHoraBanco()
        {
            var query = @" select curdate() from dual ";
            var dataHoraBanco = this.Query<DateTime>(query, null).FirstOrDefault();

            return dataHoraBanco;
        }

        #endregion Utilitarios 

        #endregion Publicos
    }
}
