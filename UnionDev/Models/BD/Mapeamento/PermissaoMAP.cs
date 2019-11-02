using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Mapeamento
{
    public class PermissaoMAP : EntityTypeConfiguration<Permissao>
    {
        public PermissaoMAP()
        {
            ToTable("TB_PERMISSAO");

            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("PER_CODIGO");
            Property(x => x.Descricao).HasColumnName("PER_DESCRICAO");
            Property(x => x.Ativo).HasColumnName("PER_ATIVO");

        }
    }
}