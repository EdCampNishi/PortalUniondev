using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;
using UnionDev.Models.Services;

namespace UnionDev.Models.ModelsBusiness
{
    public class UsuariosBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public UsuariosBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }

        public Tuple<JObject,Usuarios> ObterUsuario(Usuarios usuario)
        {

            JObject obj = new JObject();
            StringBuilder senha = new StringBuilder();

            var senhaBytes = usuario.Login == "admin" ?
                Encoding.ASCII.GetBytes(usuario.Senha) : Encoding.ASCII.GetBytes(usuario.Login +";"+ usuario.Senha);

            var encrypter = new SHA256Managed();
            var hash = encrypter.ComputeHash(senhaBytes);

            try
            {
                var passBD = uow.UsuariosRepositorio.Get(x => x.SenhaCriptografada == hash);
                if (passBD != null)
                {
                    obj.Add(new JProperty("Status", "ok"));
                    obj.Add(new JProperty("Permissao", passBD.PermissaoCodigo));
                    
                    return new Tuple<JObject, Usuarios>(obj, passBD);
                }
                return null;
            }
            catch (Exception ex)
            {
                obj.Add(new JProperty("Status", "erro"));
                return new Tuple<JObject, Usuarios>(obj,null);
            }



        }

        public JObject CriarUsuario(Cliente cli)
        {
            JObject obj = new JObject();

            StringBuilder senha = new StringBuilder();
            //pbkdf2
            //byte[] senhaBytes = Encoding.ASCII.GetBytes(usuario.Senha);
            //var encrypter = new SHA256Managed();
            //var hash = encrypter.ComputeHash(senhaBytes);



            //MD5 md5 = MD5.Create();
            //byte[] entrada = Encoding.ASCII.GetBytes(usuario.Login + "//" + usuario.Senha);
            //byte[] hash = md5.ComputeHash(entrada);
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < hash.Length; i++)
            //{
            //    senha.Append(hash[i].ToString());
            //}
            Usuarios usu = new Usuarios
            {
                SenhaCriptografada = (cli.Email + ";" + "12345").Encriptar(),
                Ativo = true,
                Apelido = cli.RazaoSocial,
                Login = cli.Email,
                PermissaoCodigo = 2                
            };

            if (uow.UsuariosRepositorio.Adicionar(usu))
            {
                if (uow.Commit())
                {
                    obj.Add(new JProperty("status", "ok"));
                    return obj;
                }
                else
                {
                    obj.Add(new JProperty("status", uow.GetErro()));
                    return obj;
                }
            }
            else
            {
                obj.Add(new JProperty("status", uow.GetErro()));
                return obj;
            }
        }

        public Usuarios Login(string email, string senha)
        {
            ControleUsuario controleUsu = new ControleUsuario();
            //var cripto = senha;
            //var cripto = email + ";" + senha;
            email = email.ToLower();
            var senhaCripto = email == "admin" ? senha.Encriptar() : (email +";"+ senha).Encriptar();

            Usuarios usu = controleUsu.Logar(email, senhaCripto);

            return usu;
            

        }

        public Usuarios ObterPorId(int codigo)
        {
            var usuario = uow.UsuariosRepositorio.GetByID(codigo);
            if (usuario == null)
                return usuario;
            else
            {
                usuario.id_criptografado = usuario.Codigo.ToString().EncriptarString();
                usuario.Permissao = uow.PermissoesRepositorio.GetByID(usuario.PermissaoCodigo);
            }            
            return usuario;
        }
    }
}