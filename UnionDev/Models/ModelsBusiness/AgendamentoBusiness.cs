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


        public JArray ConsultaAgendamentoGeral()
        {
            JArray arr = new JArray();

            var consultadas = uow.AgendamentosRepositorio.GetAllAsNoTracking(x => x.Cancelado == false && x.Concluido == false).ToList();
            foreach (var consulta in consultadas)
            {
                arr.Add(new JObject(new JProperty("title", consulta.Objetivo),
                                    new JProperty("start", consulta.Data)));
            };
            return arr;
        }

        public IList<Agendamento> ConsultaAgendamentoDoDia()
        {
            try
            {
                var agendamento = uow.AgendamentosRepositorio.GetAllAsNoTracking(x => x.Data == DateTime.Now).ToList();

                return agendamento;
            }
            catch(Exception ex)
            {
                return null;
            }

        }

        public JArray ConsultaHorarios(DateTime date)
        {
            JArray arr = new JArray();

            var consultas = uow.AgendamentosRepositorio.GetAllAsNoTracking(x => x.Data == date).Select(x => x.HoraInicio).ToList();
            List<TimeSpan> horarios = new List<TimeSpan>()
            {
                new TimeSpan(08,00,00),
                new TimeSpan(10,00,00),
                new TimeSpan(14,00,00),
                new TimeSpan(16,00,00)
            };

            var horariosDisponiveis = new List<TimeSpan>();
            
            foreach (var hora in horarios)
            {
                if (!consultas.Contains(hora))
                {
                    horariosDisponiveis.Add(hora);
                }
            }


            foreach (var hora in horariosDisponiveis)
            {
                arr.Add(new JObject(new JProperty("hora", hora)));
            }

            return arr;
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
                    consultado.NomeCandidato = agendamento.NomeCandidato;
                    consultado.Objetivo = agendamento.Objetivo;
                    consultado.Descricao = agendamento.Descricao;
                    consultado.Pendente = true;
                    consultado.Cancelado = false;
                    consultado.Concluido = false;

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
                agendamento.Pendente = true;
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

        public IList<Agendamento> ConsultaPorDia(DateTime data)
        {
            IList<Agendamento> listaConsultas = null;
            if (data != null)
                listaConsultas = uow.AgendamentosRepositorio.GetAllAsNoTracking(x => x.Data == data).ToList();
            return listaConsultas;
        }

        public JObject ConsultaAgendamentoPorId(int id)
        {
            var agendamento = uow.AgendamentosRepositorio.GetByID(id);

            JObject obj = new JObject();

            if(agendamento != null)
            {

                obj.Add(new JProperty("Codigo", agendamento.Codigo));
                obj.Add(new JProperty("Candidato", agendamento.NomeCandidato));
                obj.Add(new JProperty("Descricao", agendamento.Descricao));
                obj.Add(new JProperty("Horario", agendamento.HoraInicio));
            }
            else
            {
                obj.Add(new JProperty("erro", "Não foi encontrado agendamento"));
            }

            return obj;
        }

        public IList<Agendamento> ConsultaTodosAgendamentos()
        {
            var listaAgendamentos = uow.AgendamentosRepositorio.GetAllAsNoTracking(x => x.Data > DateTime.Now).ToList();

            return listaAgendamentos;
        }
    }
}