using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

namespace UnionDev.Models.ModelsBusiness
{
    public class CandidatoBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public CandidatoBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }

        public Candidato CriarCandidato(Candidato candidato)
        {
            JObject obj = new JObject();

            ClienteBusiness cliBusiness = new ClienteBusiness();

            if (uow.CandidatosRepositorio.Adicionar(candidato))
            {
                if (uow.Commit())
                { 
                    return candidato;
                }
                else
                {
                    return null;
                }
            }
            else
            { 
                return null;
            }

        }

        public List<Candidato> ObterTodosCandidato()
        {
            List<Candidato> candidatos = uow.CandidatosRepositorio.GetAllAsNoTracking().ToList();

            return candidatos;
        }

        public List<Candidato> ObterCandidatosPorEmpresa(Cliente cliente)
        {
            List<Candidato> candidatos = uow.CandidatosRepositorio.GetAllAsNoTracking(x => x.ClienteCodigo == cliente.Codigo).ToList();

            return candidatos;
        }

        public JObject ObterCandidatoPorId(int id)
        {
            Candidato candidato;
            try
            {
                candidato = uow.CandidatosRepositorio.GetByID(id);
                JObject candidadoObj = JObject.FromObject(candidato);

                return candidadoObj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}