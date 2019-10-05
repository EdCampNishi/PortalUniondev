using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Candidato
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
        public string Empresa { get; set; }
    }
}