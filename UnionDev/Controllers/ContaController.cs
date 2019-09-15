using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnionDev.Models;
using System.Data.SqlClient;

namespace UnionDev.Controllers
{
    public class ContaController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
                                                                //DEPENDE DO BANCO PARA PROSSEGUIR COM A VALIDAÇÃO
            con.ConnectionString = @"data source=(nome do servidor); databse=(nome da base) integrated security=(segurança);";
        }

        [HttpPost]
        public ActionResult Verifica(Conta conta)
        {
            connectionString();
            con.Open();
            command.Connection = con;
            command.CommandText = "SELECT * FROM (TABELA DE LOGIN) WHERE (COLUNA DE LOGIN)='"+conta.Nome+"' AND (COLUNA DE SENHA)='"+conta.Senha+"'";
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }

            
        }

        public ActionResult PainelControleCliente()
        {
            return View();
        }

        public ActionResult CadastroCandidatoCliente()
        {
            return View();
        }
    }
}