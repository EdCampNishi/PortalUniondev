using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using UnionDev.Models.BD.Interfaces;
using UnionDev.Models.BD.Mapeamento;

namespace UnionDev.Models.BD
{
    public class Contexto : DbContext, IContexto
    {
        public Contexto():base("ModeloDados")
        {

        }
               
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClienteMAP());
            modelBuilder.Configurations.Add(new EnderecoMAP());
            modelBuilder.Configurations.Add(new FuncionarioMAP());
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}