using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UnionDev.Models.BD.Interfaces;

namespace UnionDev.Models.BD
{
    public class UNIONDEVDataBase : IDataBase
    {
        private SqlConnection _conexao = null;
        private SqlCommand _comando = null;
        private SqlDataAdapter _adapter = null;

        public IDbDataAdapter CreateAdpater()
        {
            _adapter = new SqlDataAdapter();
            return _adapter;
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            _comando = new SqlCommand(procName, (SqlConnection)connection);
            _comando.CommandType = CommandType.StoredProcedure;
            _comando.Parameters.Clear();
            return _comando;
        }

        public IDbConnection CriarConexao()
        {
            string connectionString = Factory.ConnectionFactory.BuscarConexaoUNIONDEV();
            _conexao = new SqlConnection(connectionString);
            _conexao.Open();
            return _conexao;
        }
    }
}