using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnionDev.Models;
using UnionDev.Models.BD.Interfaces;
using UnionDev.Models.BD.Repositorio;
using UnionDev.Models.BD.Repositorio.Interfaces;
using UnionDev.Models.ModelsBusiness;
using UnionDev.Models.ModelsBusiness.Interfaces;

namespace UnionDev.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult PainelControleAdmin()
        {
            return View();
        }

        public ActionResult CadastroClienteAdmin()
        {
            return View();
        }

        public ActionResult ConsultaClienteAdmin()
        {
            ClienteBusiness clienteBusiness = new ClienteBusiness();
            var cli = clienteBusiness.ObterTodosClientes();

            return View(cli);
        }


        // MÉTODOS PARA CRUD
        [HttpGet]
        public string ConsultarTodosClientes()
        {
            ClienteBusiness cliBusiness = new ClienteBusiness();
            IList<Cliente> cli = cliBusiness.ObterTodosClientes();
            return cli.ToString();
        }

        [HttpGet]
        public string ConsultarClientePorId(int id)
        {
            ClienteBusiness cliBusiness = new ClienteBusiness();
            Cliente cli = cliBusiness.ObterPorId(id);
            return cli.ToString();
        }

        [HttpPost]
        public string SalvarCliente(Cliente cliente, Endereco endereco)
        {
            cliente.Endereco = endereco;
            ClienteBusiness cliBusiness = new ClienteBusiness();
            JObject cli = cliBusiness.CadastrarCliente(cliente);
            return cli.ToString();
        }

        [HttpPost]
        public string EditarCliente(string codigo)
        { 
            ClienteBusiness cliBusiness = new ClienteBusiness();
            JObject obj = cliBusiness.EditarCliente(int.Parse(codigo));
            return obj.ToString();
        }

        [HttpPost]
        public string RemoverCliente(string codigo)
        {
            ClienteBusiness cliBusiness = new ClienteBusiness();
            JObject cli = cliBusiness.RemoverCliente(int.Parse(codigo));
            return cli.ToString();
        }
    }
}