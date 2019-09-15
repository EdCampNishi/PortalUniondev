using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}