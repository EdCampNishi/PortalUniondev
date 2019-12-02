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
using System.Web.Security;
using UnionDev.Models.Services;

namespace UnionDev.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            bool logado = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if(logado)
            {
                if(Request.QueryString["ReturnUrl"] != null)
                {
                    return RedirectToAction("LogOff", new { ReturnUrl = Request.QueryString["ReturnUrl"] });
                }
                return RedirectToAction("PainelControleCliente", "Cliente");
            }
            else
            {
                return View(new Usuarios());
            }            
        }

        public ActionResult Logar(Usuarios usu, FormCollection form)
        {
            if (!(ModelState.IsValidField("Email") && ModelState.IsValidField("Senha")))
            {
                return RedirectToAction("Login", new { valid = "campos" });
            }
            else
            {
                UsuariosBusiness usuBusiness = new UsuariosBusiness();
                Usuarios usuLogado = usuBusiness.Login(usu.Login, usu.Senha);
                if(usuLogado == null)
                {
                    return RedirectToAction("Login", new { valid = "usuarioousenha" });
                }

                if(Request.Form["chkcontinuarLogado"] == "on")
                {
                    FormsAuthentication.SetAuthCookie(usu.Login, true);
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(usu.Login, false);
                }

                FormsAuthenticationTicket nomeusu = new FormsAuthenticationTicket(

                    1,
                    "Nomeusu",
                    DateTime.Now,
                    DateTime.Now.AddDays(10),
                    true,
                    usuLogado.Login,
                    FormsAuthentication.FormsCookiePath);

                FormsAuthenticationTicket id = new FormsAuthenticationTicket(
                    1,
                    "codigousu",
                    DateTime.Now,
                    DateTime.Now.AddDays(20),
                    true,
                    Convert.ToString(usuLogado.Codigo),
                    FormsAuthentication.FormsCookiePath);

                string e_nomeusu = FormsAuthentication.Encrypt(nomeusu);
                string e_id = FormsAuthentication.Encrypt(id);

                Response.Cookies.Add(new HttpCookie("nomePortal", e_nomeusu));
                Response.Cookies.Add(new HttpCookie("idPortal", e_id));

                return RedirectToAction("PainelControleAdmin", "Admin");

            }
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            string[] limpar = new string[] { "nomePortal", "idPortal", "codemPortal" };
            string[] todos = Request.Cookies.AllKeys;

            foreach( string cookie in todos)
            {
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
            if(Request.QueryString["ReturnUrl"] != null)
            {
                return RedirectToAction("Login", new { ReturnUrl = Request.QueryString["ReturnUrl"] });
            }
            return RedirectToAction("Login");

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Usuarios usuario)
        {
            var validacao = ValidaUsuario(usuario);
            if (validacao != null)
            {
                if (int.Parse(validacao["Permissao"].ToString()) == 1)
                {
                    var nome = usuario.Login.Encriptar();
                    return RedirectToAction("PainelControleAdmin", "Admin");
                }
                else
                    return RedirectToAction("Index", "Cliente");
            }
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