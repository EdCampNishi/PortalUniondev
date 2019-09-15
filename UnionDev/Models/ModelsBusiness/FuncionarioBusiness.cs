using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

namespace UnionDev.Models.ModelsBusiness
{
    public class FuncionarioBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public FuncionarioBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }

        public Funcionario ObterPorId(int id)
        {
            Funcionario fun;
            try
            {
                fun = uow.FuncionariosRepositorio.GetByID(id);

                return fun;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<Funcionario> ObterTodosFuncionario()
        {
            IList<Funcionario> funcionarios = uow.FuncionariosRepositorio.GetAllAsNoTracking().ToList();

            return funcionarios;
        }

        public JObject CadastrarFuncionario(Funcionario fun)
        {
            JObject obj = new JObject();

            if (uow.FuncionariosRepositorio.Adicionar(fun))
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

        public JObject EditarFuncionario(Funcionario fun)
        {
            JObject obj = new JObject();


            if (uow.FuncionariosRepositorio.Atualizar(fun))
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

        public JObject RemoverFuncionario(Funcionario fun)
        {
            JObject obj = new JObject();

            if (uow.FuncionariosRepositorio.Deletar(fun))
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