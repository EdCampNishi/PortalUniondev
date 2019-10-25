﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnionDev.Models.BD;
using UnionDev.Models.BD.Repositorio;

namespace UnionDev.Models.ModelsBusiness
{
    public class CandidatoBusiness
    {
        private UnitOfWork uow;
        private Contexto contexto;

        public CandidatoBusiness()
        {
            contexto = new Contexto();
            uow = new UnitOfWork(contexto);
        }

        public Candidato CriarCandidato(Candidato candidato)
        {
            JObject obj = new JObject();

            if (uow.CandidatosRepositorio.Adicionar(candidato))
            {
                if (uow.Commit())
                { 
                    return candidato;
                }
                else
                {
                    return null;
                }
            }
            else
            { 
                return null;
            }

        }

        public Candidato ObterCandidato(Candidato candidato)
        {


            return candidato;
        }
    }
}