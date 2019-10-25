﻿using Newtonsoft.Json;
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

        public ActionResult RelatoriosAdmin()
        {
            return View();
        }

        public ActionResult AjudaAdmin()
        {
            return View();
        }

        public ActionResult ControleAtendimentosAdmin()
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
        public IList<Cliente> ConsultarTodosClientes()
        {
            ClienteBusiness cliBusiness = new ClienteBusiness();
            var cli = cliBusiness.ObterTodosClientes();
            return cli;
        }

        [HttpGet]
        public JObject ConsultarClientePorId(int id)
        {
            ClienteBusiness cliBusiness = new ClienteBusiness();
            JObject cli = cliBusiness.ObterClientePorId(id);
            return cli;
        }

        [HttpPost]
        public void SalvarCliente(Cliente cliente, Endereco endereco)
        {
            cliente.Endereco = endereco;
            ClienteBusiness cliBusiness = new ClienteBusiness();
            JObject cli = cliBusiness.CadastrarCliente(cliente);
            ConsultaClienteAdmin();
        }

        [HttpPost]
        public string EditarCliente(Cliente cliente)
        { 
            ClienteBusiness cliBusiness = new ClienteBusiness();
            JObject obj = cliBusiness.EditarCliente(cliente);
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