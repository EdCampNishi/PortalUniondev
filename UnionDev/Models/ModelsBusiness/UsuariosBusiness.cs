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

            var senhaBytes = Encoding.ASCII.GetBytes(usuario.Senha);

            var encrypter = new SHA256Managed();
            var hash = encrypter.ComputeHash(senhaBytes);

            try
            {
                var passBD = uow.UsuariosRepositorio.Get(x => x.SenhaCriptografada == hash);
                if (passBD != null)
                {
                    obj.Add(new JProperty("Status", "ok"));
                    obj.Add(new JProperty("Permissao", passBD.PermissaoCodigo));
                    
                    return obj;
                }
                return null;
            }
            catch (Exception ex)
            {
                obj.Add(new JProperty("Status", "erro"));
                return obj;
            }



        }

        public JObject CriarUsuario(Usuarios usuario)
        {
            JObject obj = new JObject();

            StringBuilder senha = new StringBuilder();
            //pbkdf2
            byte[] senhaBytes = Encoding.ASCII.GetBytes(usuario.Senha);
            var encrypter = new SHA256Managed();
            var hash = encrypter.ComputeHash(senhaBytes);



            //MD5 md5 = MD5.Create();
            //byte[] entrada = Encoding.ASCII.GetBytes(usuario.Login + "//" + usuario.Senha);
            //byte[] hash = md5.ComputeHash(entrada);
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < hash.Length; i++)
            //{
            //    senha.Append(hash[i].ToString());
            //}
            usuario.SenhaCriptografada = hash;
            usuario.Ativo = true;

            if (uow.UsuariosRepositorio.Adicionar(usuario))
            {
                if (uow.Commit())
                {
                    obj.Add(new JProperty("status", "ok"));
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