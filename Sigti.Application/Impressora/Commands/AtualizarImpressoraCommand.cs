﻿using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application
{
    public class AtualizarImpressoraCommand : Notifiable<Notification>,  ICommand
    {
        public AtualizarImpressoraCommand(string modelo, string patrimonio,
            bool alugado, Guid setorId, Guid localizacaoId, string observacao, 
            string ip, ETipoConexaoImpressora conexao, ETipoImpressora tipo)
        {
            Modelo = modelo;
            Patrimonio = patrimonio;
            Alugado = alugado;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            Ip = ip;
            Conexao = conexao;
            Tipo = tipo;
        }

        public string Modelo { get;  set; }
        public string Patrimonio { get;  set; }
        public bool Alugado { get;  set; }
        public Guid SetorId { get;  set; }
        public Guid LocalizacaoId { get;  set; }
        public string Observacao { get;  set; }
        public string Ip { get;  set; }
        public ETipoConexaoImpressora Conexao { get;  set; }
        public ETipoImpressora Tipo { get;  set; }
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
