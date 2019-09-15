using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace UnionDev.Models.BD.Mapeamento
{
    public class EnderecoMAP : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMAP()
        {
            //Tabela
            ToTable("TB_ENDERECO");

            //Chave Primaria
            HasKey(x => x.Codigo);

            //Propriedade => Coluna
            Property(x => x.Codigo).HasColumnName("END_CODIGO");
            Property(x => x.Bairro).HasColumnName("END_BAIRRO");
            Property(x => x.CEP).HasColumnName("END_CEP");
            Property(x => x.Cidade).HasColumnName("END_CIDADE");
            Property(x => x.Estado).HasColumnName("END_ESTADO");
            Property(x => x.Logradouro).HasColumnName("END_LOGRADOURO");
            Property(x => x.Numero).HasColumnName("END_NUMERO");
        }
    }
}