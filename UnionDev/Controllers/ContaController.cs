using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnionDev.Models;
using System.Data.SqlClient;
using UnionDev.Models.ModelsBusiness;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace UnionDev.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuarios usuario)
        {
            var validacao = ValidaUsuario(usuario);
            if (validacao != null)
                return RedirectToAction("PainelControleAdmin", "Admin");
            else
                return RedirectToAction("Login");
        }

        public string CriarUsuario(Usuarios usuario)
        {
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var usu = usuBusiness.CriarUsuario(usuario);

            return "ok";
        }

        public JObject ValidaUsuario(Usuarios usuario)
        {
            AdminController contrl = new AdminController();
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var usu = usuBusiness.ObterUsuario(usuario);
            if (usu != null)
            {
                return usu;
            }
            else
                return null;
        }

        //[HttpPost]
        //public ActionResult ValidaUsuario(Usuarios usuario)
        //{
        //    UsuariosBusiness usuBusiness = new UsuariosBusiness();
        //    var usu = usuBusiness.ObterUsuario(usuario);
        //    if (usu != null)
        //    {
        //        if (usu.Ativo == true && usu.Codigo != 0)
        //        {
        //            return RedirectToAction("CadastroClienteAdmin", "Admin");
        //        }
        //    }
        //    return RedirectToAction("Login");
        //}


        public ActionResult PainelControleCliente()
        {
            return View();
        }


        public ActionResult CadastroCandidatoCliente()
        {
            return View();
        }

        public ActionResult RelatoriosCliente()
        {
            return View();
        }

        public ActionResult AjudaCliente()
        {
            return View();
        }

        public ActionResult ControleAtendimentoCliente()
        {
            return View();
        }

        public JObject CadastrarCandidato(Candidato candidato)
        {
            JObject retornoCriação = new JObject();
            CandidatoBusiness canBusiness = new CandidatoBusiness();
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var can = canBusiness.CriarCandidato(candidato);
            if (can != null)
            {
                Usuarios usu = new Usuarios
                {
                    Login = candidato.CPF,
                    Senha = "12345",
                    Ativo = true
                };
                var usuarioCriado = usuBusiness.CriarUsuario(usu);
                if (usuarioCriado["status"].ToString() == "ok") 
                    return usuarioCriado;
            }
            retornoCriação.Add(new JProperty("status", "nok"));
            return retornoCriação;
        }
    }
}