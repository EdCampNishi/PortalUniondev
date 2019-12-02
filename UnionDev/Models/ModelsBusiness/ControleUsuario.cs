using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

namespace UnionDev.Models.ModelsBusiness
{
    public class ControleUsuario
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public ControleUsuario()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }
        public Usuarios Logar(string email, string senha)
        {
            try
            {
                Usuarios usuario = uow.UsuariosRepositorio.Get(x => x.Login == email && x.Senha == senha && x.Ativo == false);

                if(usuario == null)
                {
                    return null;
                }
                else
                {
                    return usuario;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}