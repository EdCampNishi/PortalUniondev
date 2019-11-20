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


        public ActionResult Agenda()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CriarAgendamento(Models.Agendamento agendamento)
        {
            Models.ModelsBusiness.AgendamentoBusiness agBusiness = new Models.ModelsBusiness.AgendamentoBusiness();
            Models.Agendamento ag = agBusiness.SalvarAgendamento(agendamento);

            return RedirectToAction("ControleAtendimentoCliente");
        }

        public JObject CadastrarCandidato(Candidato candidato)
        {
            JObject retornoCriação = new JObject();
            CandidatoBusiness canBusiness = new CandidatoBusiness();
            UsuariosBusiness usuBusiness = new UsuariosBusiness();
            var can = canBusiness.CriarCandidato(candidato);
            if (can != null)
            {
                Usuarios usu = new Usuarios
                {
                    Login = candidato.CPF,
                    Senha = "12345",
                    Ativo = true
                };
                var usuarioCriado = usuBusiness.CriarUsuario(usu);
                if (usuarioCriado["status"].ToString() == "ok")
                    return usuarioCriado;
            }
            retornoCriação.Add(new JProperty("status", "nok"));
            return retornoCriação;
        }
    }
}