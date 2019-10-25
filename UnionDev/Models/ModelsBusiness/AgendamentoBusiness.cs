using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

namespace UnionDev.Models.ModelsBusiness
{
    public class AgendamentoBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public AgendamentoBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }


        public Agendamento SalvarAgendamento(Agendamento agendamento)
        {

            if (agendamento.Codigo > 0)
            {
                var consultado = uow.AgendamentosRepositorio.Get(x => x.Codigo == agendamento.Codigo);
                if (consultado != null)
                {
                    consultado.Data = agendamento.Data;
                    consultado.HoraInicio = agendamento.HoraInicio;
                    consultado.HoraFim = agendamento.HoraFim;
                    consultado.NomeCandidato = agendamento.NomeCandidato;
                    consultado.Objetivo = agendamento.Objetivo;
                    consultado.Descricao = agendamento.Descricao;

                    if (uow.AgendamentosRepositorio.Atualizar(consultado))
                    {
                        if (!uow.Commit())
                        {
                            return null;
                        }
                        return consultado;
                    }
                    return null;
                }
            }
            else
            {
                if (uow.AgendamentosRepositorio.Adicionar(agendamento))
                {
                    if (!uow.Commit())
                    {
                        return null;
                    }
                    return agendamento;
                }
                return null;
            }
            return null;
        }
    }
}