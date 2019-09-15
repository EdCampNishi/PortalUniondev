using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Interfaces
{
    public interface IDataBase
    {
        IDbConnection CriarConexao();
        IDbCommand CreateCommand();
        IDbCommand CreateCommand(string commandText, IDbConnection connection);
        IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection);
        IDbDataAdapter CreateAdpater();
    }
}