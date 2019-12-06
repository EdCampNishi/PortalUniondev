using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Relatorio
    {
        public int Codigo { get; set; }

        [DisplayName("Data Inicial")]
        public DateTime DataInicio { get; set; }

        [DisplayName("Data Final")]
        public DateTime DataFim { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}