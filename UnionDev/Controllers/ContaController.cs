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
        [AllowAnonymous]
        public ActionResult Login(Usuarios usuario)
        {
            var validacao = ValidaUsuario(usuario);
            if (validacao != null)
                if(int.Parse(validacao["Permissao"].ToString()) == 1 )
                    return RedirectToAction("PainelControleAdmin", "Admin");
                else
                    return RedirectToAction("Index", "Cliente");
            else
            {
                ViewBag.Message = "Usuário Inválido.";
                return View(usuario);
            }
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







    }
}