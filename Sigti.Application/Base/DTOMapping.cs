﻿using AutoMapper;
using Sigti.Application.DTO;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;

namespace Sigti.Application.Base
{
    public class DTOMapping:Profile
    {
        public DTOMapping()
        {
          CreateMap<Computador,ComputadorDTO>();  
          CreateMap<Localizacao,LocalizacaoDTO>();  
       
          CreateMap<AdicionarComputadorCommand,Computador>();  
          CreateMap<AtualizarComputadorCommand,Computador>();  
          CreateMap<AdicionarLocalizacaoCommand,Localizacao>();  
          CreateMap<AtualizarLocalizacaoCommand,Localizacao>();  
          
        }
       
    }
}
