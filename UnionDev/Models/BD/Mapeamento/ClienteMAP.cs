using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace UnionDev.Models.BD.Mapeamento
{
    public class ClienteMAP : EntityTypeConfiguration<Cliente>
    {
        public ClienteMAP()
        {
            //Tabela
            ToTable("TB_CLIENTES");

            //Chave Primaria
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("CLI_CODIGO");
            Property(x => x.RazaoSocial).HasColumnName("CLI_RAZAO_SOCIAL");
            Property(x => x.CNPJ).HasColumnName("CLI_CNPJ");
            Property(x => x.Ramo).HasColumnName("CLI_RAMO");
            Property(x => x.EnderecoCodigo).HasColumnName("CLI_ENDCODIGO");

            //Chave Secundaria
            //HasRequired(x => x.Endereco)
            //    .WithMany()
            //    .HasForeignKey(Y => Y.EnderecoCodigo);
       
            
        }
    }
}