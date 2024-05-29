﻿using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.DTO
{
    public class ComputadorDTO(Guid id, bool ativo, string modificadoPor, DateTime dataModificacao,
        string hostName, string processador, string memoria, string disco, string ip, string anydesk,
        string grupos, string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
        Guid setorId, Guid localizacaoId, string observacao) : IDTO
    {
        public Guid Id { get; set; } = id;
        public bool Ativo { get; set; } = ativo;
        public string ModificadoPor { get; set; } = modificadoPor;
        public DateTime DataModificacao { get; set; } = dataModificacao;
        public string HostName { get; set; } = hostName;
        public string Processador { get; set; } = processador;
        public string Memoria { get; set; } = memoria;
        public string Disco { get; set; } = disco;
        public string Ip { get; set; } = ip;
        public string Anydesk { get; set; } = anydesk;
        public string Grupos { get; set; } = grupos;
        public string UltimoUsuarioLogado { get; set; } = ultimoUsuarioLogado;
        public string Patrimonio { get; set; } = patrimonio;
        public string SistemaOperacional { get; set; } = sistemaOperacional;
        public Guid SetorId { get; set; } = setorId;
        public Guid LocalizacaoId { get; set; } = localizacaoId;
        public string Observacao { get; set; } = observacao;
    }
}
