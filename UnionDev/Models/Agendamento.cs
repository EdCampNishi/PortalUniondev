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
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Descricao { get; set; }
        public bool Pendente { get; set; }
        public bool Cancelado { get; set; }
        public bool Concluido { get; set; }
    }
}