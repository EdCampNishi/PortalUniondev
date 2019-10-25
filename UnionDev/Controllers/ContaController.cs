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

namespace UnionDev.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public string CriarUsuario(Usuarios usuario)
        {
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var usu = usuBusiness.CriarUsuario(usuario);

            return "ok";
        }

        public string ValidaUsuario(Usuarios usuario)
        {
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var usu = usuBusiness.ObterUsuario(usuario);
            if (usu != null)
            {
                return usu.ToString();
            }
            return "erro";
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

        public string CadastrarCandidato(Candidato candidato)
        {
            CandidatoBusiness canBusiness = new CandidatoBusiness();
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var can = canBusiness.CriarCandidato(candidato);
            if (can != null)
            {
                Usuarios usu = new Usuarios
                {
                    Login = can.Nome.Remove(can.Nome.IndexOf(" ")).ToLower(),
                    Senha = Encoding.ASCII.GetBytes("12345"),
                    Ativo = true
                };
                var criaUsu = usuBusiness.CriarUsuario(usu);

                return criaUsu.ToString();
            }

            return "erro";
        }
    }
}