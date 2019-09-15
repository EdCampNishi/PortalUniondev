using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace UnionDev.Models.BD.Consulta.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        T GetByID(object id);
        IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        bool Adicionar(T entity);
        bool Atualizar(T entity);
        bool Deletar(T entity);
        int Contar();
        bool AdicionarRange(IList<T> listEntity);
        bool AddUpdRange(Expression<Func<T, object>> validacao, IList<T> listEntity);
        bool RemoverRange(IList<T> listEntity);
        string GetErro();
    }
}