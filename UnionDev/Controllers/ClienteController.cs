using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnionDev.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Agenda()
        {
            return View();
        }

        [HttpPost]
        public Models.Agendamento CriarAgendamento(Models.Agendamento agendamento)
        {
            Models.ModelsBusiness.AgendamentoBusiness agBusiness = new Models.ModelsBusiness.AgendamentoBusiness();
            Models.Agendamento ag = agBusiness.SalvarAgendamento(agendamento);

            return ag;
        }
    }
}