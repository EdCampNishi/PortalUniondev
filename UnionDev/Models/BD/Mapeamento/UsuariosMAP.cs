using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Mapeamento
{
    public class UsuariosMAP : EntityTypeConfiguration<Usuarios>
    {
        public UsuariosMAP()
        {
            ToTable("TB_USUARIOS");

            //PrymaryKey
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("USU_CODIGO");
            Property(x => x.Login).HasColumnName("USU_LOGIN");
            Property(x => x.Senha).HasColumnName("USU_SENHA");
            Property(x => x.Ativo).HasColumnName("USU_ATIVO");
        }
    }
}