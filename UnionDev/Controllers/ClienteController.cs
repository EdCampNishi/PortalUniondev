using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnionDev.Models;
using UnionDev.Models.ModelsBusiness;

namespace UnionDev.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult AgendaConsulta()
        {
            return View();
        }

        public JArray ConsultaAgendaGeral()
        {
            AgendamentoBusiness agendaBusiness = new AgendamentoBusiness();
            var listaAgenda = agendaBusiness.ConsultaAgendamentoGeral();

            return listaAgenda;
        }

        public string ValidaQuantidadeConsultaPorDia(DateTime date)
        {
            AgendamentoBusiness agendamento = new AgendamentoBusiness();
            IList<Agendamento> listaAgenda = agendamento.ConsultaPorDia(date);

            if (listaAgenda.Count < 3)
                return "ok";
            else
                return null;
        }

        public JArray VerificaHorarioDisponivel(DateTime data)
        {
            AgendamentoBusiness agendamento = new AgendamentoBusiness();
            var horariosDisporniveis = agendamento.ConsultaHorarios(data);
            return horariosDisporniveis;
        }

        public ActionResult PainelControleCliente()
        {
            return View();
        }

        public ActionResult CadastroCandidatoCliente()
        {
            //CRIAR VIEWBAG PARA LISTAR TODOS OS CLIENTES CADASTRADOS E LEVAR PARA A TELA DE CADASTRO
            return View();
        }

        public ActionResult RelatoriosCliente()
        {
            return View();
        }

        public ActionResult AjudaCliente()
        {
            return View();
        }

        public ActionResult ControleAtendimentoCliente()
        {
            return View();
        }


        public ActionResult BancoCandidato()
        {
            Cliente cliente = new Cliente();
            CandidatoBusiness candidatoBusiness = new CandidatoBusiness();
            IList<Candidato> candidatos = candidatoBusiness.ObterCandidatosPorEmpresa(cliente);

            return View(candidatos);
        }

        public ActionResult Agenda()
        {
            return View();
        }

        [HttpPost]
        public JObject CriarAgendamento(Models.Agendamento agendamento)
        {
            JObject obj = new JObject();
            Models.ModelsBusiness.AgendamentoBusiness agBusiness = new Models.ModelsBusiness.AgendamentoBusiness();
            Models.Agendamento ag = agBusiness.SalvarAgendamento(agendamento);

            if (ag != null)
                obj.Add(new JProperty("status", "ok"));
            else
                obj.Add(new JProperty("status", "erro"));

            return obj;
        }

        public JObject CadastrarCandidato(Candidato candidato)
        {
            JObject retornoCriação = new JObject();
            CandidatoBusiness canBusiness = new CandidatoBusiness();
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var can = canBusiness.CriarCandidato(candidato);
            if (can != null)
            {
                retornoCriação.Add(new JProperty("status", "ok"));
                
            }
            retornoCriação.Add(new JProperty("status", "nok"));
            return retornoCriação;
        }
    }
}