using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models.ModelsBusiness.Interfaces
{
    public interface IClienteBusiness
    {
        Cliente ObterPorId(int id);
        IList<Cliente> ObterTodosClientes();
        JObject CadastrarCliente(Cliente cli);
        JObject EditarCliente(Cliente cli);
        JObject RemoverCliente(Cliente cli);
    }
}