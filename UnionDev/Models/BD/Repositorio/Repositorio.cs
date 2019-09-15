using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using UnionDev.Models.BD.Consulta.Interfaces;
using UnionDev.Models.BD.Interfaces;

namespace UnionDev.Models.BD.Consulta
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private IContexto m_Context = null;
        private Exception _erro = null;
        DbSet<T> m_DbSet;
        public Repositorio() { }

        public Repositorio(IContexto context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }


        public T GetByID(object id)
        {
            return m_Context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }
            return m_DbSet.AsQueryable();
        }
        public IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.AsNoTracking().Where(predicate);
            }
            return m_DbSet.AsNoTracking().AsQueryable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }
        public bool Adicionar(T entity)
        {
            try
            {
                m_DbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }

        }
        public bool Atualizar(T entity)
        {
            try
            {
                m_Context.Entry(entity).State = EntityState.Modified;
                //m_DbSet.Attach(entity);
                //((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }

        }
        public bool Deletar(T entity)
        {
            try
            {
                m_DbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }

        }
        public int Contar()
        {
            return m_DbSet.Count();
        }

        public bool AdicionarRange(IList<T> listEntity)
        {
            try
            {
                m_DbSet.AddRange(listEntity);
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }

        }

        public bool AddUpdRange(Expression<Func<T, object>> validacao, IList<T> listEntity)
        {
            try
            {
                m_DbSet.AddOrUpdate(validacao, listEntity.ToArray());
                return true;
            }
            catch (Exception ex)
            {

                _erro = ex;
                return false;
            }
        }

        public bool RemoverRange(IList<T> listEntity)
        {
            try
            {
                m_DbSet.RemoveRange(listEntity);
                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }

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