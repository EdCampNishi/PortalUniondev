using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Ramo { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoCodigo { get; set; }
    }
}