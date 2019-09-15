using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Mapeamento
{
    public class FuncionarioMAP : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMAP()
        {
            //Tabela
            ToTable("TB_FUNCIONARIOS");

            //Chave Primaria
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("FUN_CODIGO");
            Property(x => x.Nome).HasColumnName("FUN_NOME");
            Property(x => x.CPF).HasColumnName("FUN_CPF");
            Property(x => x.DataNascimento).HasColumnName("FUN_DATA_NASCIMENTO");
            Property(x => x.Telefone).HasColumnName("FUN_TELEFONE");
        }
    }
}