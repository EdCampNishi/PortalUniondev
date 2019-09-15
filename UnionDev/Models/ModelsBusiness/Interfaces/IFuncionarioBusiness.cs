using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnionDev.Models.ModelsBusiness.Interfaces
{
    public interface IFuncionarioBusiness
    {
        Funcionario ObterPorId(int id);
        IList<Funcionario> ObterTodosFuncionario();
        JObject CadastrarFuncionario(Funcionario fun);
        JObject EditarFuncionario(Funcionario fun);
        JObject RemoverFuncionario(Funcionario fun);
    }
}