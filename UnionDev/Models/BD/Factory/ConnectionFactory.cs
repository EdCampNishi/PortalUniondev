using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Factory
{
    public static class ConnectionFactory
    {
        public static string BuscarConexaoUNIONDEV()
        {
            var flagADO = ConfigurationManager.AppSettings["FlagADOUNIONDEV"];
            string conexao = string.Empty;
            switch (flagADO)
            {
                case "0":
                    conexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    break;

                case "1":
                    conexao = ConfigurationManager.ConnectionStrings["ModeloDados"].ConnectionString;
                    break;

                default:
                    conexao = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    break;
            }
            return conexao;

        }
    }
}