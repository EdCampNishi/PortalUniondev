using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

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

        public JObject ObterUsuario(Usuarios usuario)
        {

            JObject obj = new JObject();
            StringBuilder senha = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] entrada = Encoding.ASCII.GetBytes(usuario.Login + "//" + usuario.Senha);
            byte[] hash = md5.ComputeHash(entrada);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            var senhaPassada = senha.ToString();
            try
            {
                var passBD = uow.UsuariosRepositorio.Get(x => x.Senha == senhaPassada);
                obj.Add(new JProperty("ok", "ok"));
                return obj;
            }
            catch(Exception ex)
            {
                return null;
            }

                
            
        }

        public JObject CriarUsuario(Usuarios usuario)
        {
            JObject obj = new JObject();

            StringBuilder senha = new StringBuilder();
            //pbkdf2
            MD5 md5 = MD5.Create();
            byte[] entrada = Encoding.ASCII.GetBytes(usuario.Login + "//" + usuario.Senha);
            byte[] hash = md5.ComputeHash(entrada);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            usuario.Senha = senha.ToString();
            usuario.Ativo = true;

            if (uow.UsuariosRepositorio.Adicionar(usuario))
            {
                if (uow.Commit())
                {
                    obj.Add(new JProperty("ok", "ok"));
                    return obj;
                }
                else
                {
                    obj.Add(new JProperty("erro", uow.GetErro()));
                    return obj;
                }
            }
            else
            {
                obj.Add(new JProperty("erro", uow.GetErro()));
                return obj;
            }
        }


    }
}