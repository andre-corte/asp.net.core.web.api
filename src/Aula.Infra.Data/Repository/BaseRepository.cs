using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace Aula.Infra.Data.Repository
{
    public abstract class BaseRepository
    {
        internal IDbConnection _dbConnection => new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DbAula;Integrated Security=True;");

        protected IEnumerable<T> Listar<T>(string sql, object data) where T : class
        {
            return _dbConnection.Query<T>(sql, data, commandType: CommandType.Text);
        }

        protected T Obter<T>(string sql, object data) where T : class
        {
            return _dbConnection.QueryFirstOrDefault<T>(sql, data, commandType: CommandType.Text);
        }
        
        protected void AdicionarOuAtualizar<T>(string sql, object data) where T : class
        {
            _dbConnection.ExecuteScalar(sql, data, commandType: CommandType.Text);
        }
    }
}
