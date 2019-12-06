using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }

        [Required]
        public string RazaoSocial { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string Ramo { get; set; }
        public virtual Endereco Endereco { get; set; }
        public int EnderecoCodigo { get; set; }
    }
}