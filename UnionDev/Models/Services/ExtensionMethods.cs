using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace UnionDev.Models.Services
{
    public static class ExtensionMethods
    {
        public static byte[] Encriptar(this string texto)
        {
            byte[] textoBytes = Encoding.ASCII.GetBytes(texto);
            SHA256Managed encrypter = new SHA256Managed();

            return encrypter.ComputeHash(textoBytes);
        }
    }
}