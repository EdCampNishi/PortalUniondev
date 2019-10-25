using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Consulta;
using UnionDev.Models.BD.Repositorio;
using UnionDev.Models.BD.Repositorio.Interfaces;

namespace UnionDev.Models.ModelsBusiness
{
    public class ClienteBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public ClienteBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }

        public JObject ObterClientePorId(int id)
        {
            Cliente cli;
            try
            {
                cli = uow.ClientesRepositorio.GetByID(id);
                JObject cliObj = JObject.FromObject(cli);

                return cliObj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<Cliente> ObterTodosClientes()
        {
            IList<Cliente> clientes = uow.ClientesRepositorio.GetAllAsNoTracking().ToList();

            return clientes;
        }

        public JObject CadastrarCliente(Cliente cli)
        {
            JObject obj = new JObject();

            if (uow.ClientesRepositorio.Adicionar(cli))
            {
                uow.Commit();
                obj.Add(new JProperty("ok", "ok"));
            }
            else
            {
                obj.Add(new JProperty("erro", uow.GetErro()));
            }

            return obj;
        }

        public JObject EditarCliente(Cliente cliente)
        {
            JObject obj = new JObject();
           

            if (uow.ClientesRepositorio.Atualizar(cliente))
            {
                if(uow.Commit())
                    obj.Add(new JProperty("ok", "ok"));
                else
                    obj.Add(new JProperty("erro", uow.GetErro()));
            }
            else
            {
                obj.Add(new JProperty("erro", uow.GetErro()));

            }

            return obj;
        }

        public JObject RemoverCliente(int codigo)
        {
            JObject obj = new JObject();           

            Cliente cliente = uow.ClientesRepositorio.GetByID(codigo);
            if (uow.ClientesRepositorio.Deletar(cliente))
            {
                uow.Commit();
                obj.Add(new JProperty("ok", "ok"));
            }
            else
            {
                obj.Add(new JProperty("erro", uow.GetErro()));

            }

            return obj;

        }
    }
}
