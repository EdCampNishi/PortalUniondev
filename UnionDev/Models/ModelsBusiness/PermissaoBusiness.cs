using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

namespace UnionDev.Models.ModelsBusiness
{
    public class PermissaoBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public PermissaoBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }

    }
}