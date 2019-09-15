using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Interfaces
{
    public interface IContexto
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
        DbEntityEntry Entry(object entity);
    }
}