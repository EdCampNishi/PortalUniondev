using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Mapeamento
{
    public class AgendamentoMAP : EntityTypeConfiguration<Agendamento>
    {
        public AgendamentoMAP()
        {
            //Tabela
            ToTable("TB_AGENDAMENTO");

            //Chave Primaria
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("AGE_CODIGO");
            Property(x => x.NomeCandidato).HasColumnName("AGE_CANDIDATO");
            Property(x => x.Objetivo).HasColumnName("AGE_OBJETIVO");
            Property(x => x.Data).HasColumnName("AGE_DATA");
            Property(x => x.HoraInicio).HasColumnName("AGE_INICIO");
            Property(x => x.HoraFim).HasColumnName("AGE_FIM");
            Property(x => x.Descricao).HasColumnName("AGE_DESCRICAO");
        }
    }
}