using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Agendamento
    {
        public int Codigo { get; set; }
        public string NomeCandidato { get; set; }
        public string Objetivo { get; set; }
        public string Data { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFim { get; set; }
        public string Descricao { get; set; }
    }
}