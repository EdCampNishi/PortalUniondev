using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Usuarios
    {
        public int Codigo { get; set; }
        [NotMapped]
        public string id_criptografado { get; set; }
        [Required]
        public string Login { get; set; }
        [NotMapped]
        public string Senha { get; set; }
        public byte[] SenhaCriptografada { get; set; }
        public bool Ativo { get; set; }

        public Permissao Permissao { get; set; }
        public int PermissaoCodigo { get; set; }

        public string Apelido { get; set; }
        [NotMapped]
        public string Path_Imagem { get; set; }

    }
}