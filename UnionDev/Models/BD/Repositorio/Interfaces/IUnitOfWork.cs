using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD.Consulta.Interfaces;

namespace UnionDev.Models.BD.Repositorio.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
        IRepositorio<Models.Cliente> ClientesRepositorio { get; }
        IRepositorio<Models.Endereco> EnderecosRepositorio { get; }
        IRepositorio<Models.Funcionario> FuncionariosRepositorio { get; }
        IRepositorio<Models.Usuarios> UsuariosRepositorio { get; }
        IRepositorio<Models.Candidato> CandidatosRepositorio { get; }
        string GetErro();
    }
}