using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD.Consulta;
using UnionDev.Models.BD.Consulta.Interfaces;
using UnionDev.Models.BD.Interfaces;
using UnionDev.Models.BD.Repositorio.Interfaces;

namespace UnionDev.Models.BD.Repositorio
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IContexto _contexto = null;
        private Exception _erro = null;

        private IRepositorio<Models.Cliente> clientesRepositorio = null;
        private IRepositorio<Models.Endereco> enderecosRepositorio = null;
        private IRepositorio<Models.Funcionario> funcionariosRepositorio = null;
        private IRepositorio<Models.Usuarios> usuariosRepositorio = null;
        private IRepositorio<Models.Candidato> candidatosRepositorio = null;

        public UnitOfWork(IContexto contexto)
        {
            _contexto = contexto;
        }
        public bool Commit()
        {
            try
            {
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }
        }

        public IRepositorio<Models.Cliente> ClientesRepositorio
        {
            get
            {
                if(clientesRepositorio == null)
                {
                    clientesRepositorio = new Repositorio<Models.Cliente>(_contexto);

                }
                return clientesRepositorio;
            }
        }

        public IRepositorio<Models.Endereco> EnderecosRepositorio
        {
            get
            {
                if (enderecosRepositorio == null)
                {
                    enderecosRepositorio = new Repositorio<Models.Endereco>(_contexto);

                }
                return enderecosRepositorio;
            }
        }

        public IRepositorio<Models.Funcionario> FuncionariosRepositorio
        {
            get
            {
                if (funcionariosRepositorio == null)
                {
                    funcionariosRepositorio = new Repositorio<Models.Funcionario>(_contexto);

                }
                return funcionariosRepositorio;
            }
        }

        public IRepositorio<Models.Usuarios> UsuariosRepositorio
        {
            get
            {
                if(usuariosRepositorio == null)
                {
                    usuariosRepositorio = new Repositorio<Models.Usuarios>(_contexto);
                }
                return usuariosRepositorio;
            }
        }

        public IRepositorio<Models.Candidato> CandidatosRepositorio
        {
            get
            {
                if (candidatosRepositorio == null)
                {
                    candidatosRepositorio = new Repositorio<Models.Candidato>(_contexto);
                }
                return candidatosRepositorio;
            }
        }

        

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public string GetErro()
        {
            if (_erro == null)
                return "";
            while (_erro.InnerException != null)
                _erro = _erro.InnerException;

            return _erro.Message;
        }
    }
}