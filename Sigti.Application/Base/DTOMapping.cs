﻿using AutoMapper;
using Sigti.Application.DTO;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;

namespace Sigti.Application.Base
{
    public class DTOMapping : Profile
    {
        public DTOMapping()
        {
            CreateMap<Computador, ComputadorDTO>();
            CreateMap<Localizacao, LocalizacaoDTO>();
            CreateMap<Impressora, ImpressoraDTO>();
            CreateMap<Setor, SetorDTO>();
            CreateMap<Controladora, ControladoraDTO>();
            CreateMap<AcessoControladora, AcessoControladoraDTO>();

            CreateMap<AdicionarComputadorCommand, Computador>();
            CreateMap<AtualizarComputadorCommand, Computador>();
            CreateMap<AdicionarLocalizacaoCommand, Localizacao>();
            CreateMap<AtualizarLocalizacaoCommand, Localizacao>();
            CreateMap<AdicionarSetorCommand, Setor>();
            CreateMap<AtualizarSetorCommand, Setor>();
            CreateMap<AdicionarImpressoraCommand, Impressora>();
            CreateMap<AtualizarImpressoraCommand, Impressora>();
            CreateMap<AdicionarControladoraCommand, Controladora>();
            CreateMap<AtualizarControladoraCommand, Controladora>();
            CreateMap<AdicionarAcessoControladoraCommand, AcessoControladora>();
            CreateMap<AtualizarAcessoControladoraCommand, AcessoControladora>();
        }

    }
}
