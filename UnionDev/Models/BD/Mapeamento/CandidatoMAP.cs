using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace UnionDev.Models.BD.Mapeamento
{
    public class CandidatoMAP : EntityTypeConfiguration<Candidato>
    {
        public CandidatoMAP()
        {
            //Tabela
            ToTable("TB_CANDIDATOS");

            //Chave Primaria
            HasKey(x => x.Codigo);

            Property(x => x.Codigo).HasColumnName("CAN_CODIGO");
            Property(x => x.Nome).HasColumnName("CAN_NOME");
            Property(x => x.CPF).HasColumnName("CAN_CPF");
            Property(x => x.Nascimento).HasColumnName("CAN_NASCIMENTO");
            Property(x => x.Sexo).HasColumnName("CAN_SEXO");
            Property(x => x.Cargo).HasColumnName("CAN_CARGO");
            Property(x => x.Setor).HasColumnName("CAN_SETOR");
            Property(x => x.ClienteCodigo).HasColumnName("CAN_CLICODIGO");

        }
    }
}