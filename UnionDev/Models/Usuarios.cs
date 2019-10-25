using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models
{
    public class Usuarios
    {
        public int Codigo { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }
        public bool Ativo { get; set; }

    }
}