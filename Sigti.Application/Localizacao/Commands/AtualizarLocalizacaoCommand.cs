﻿using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application
{
    public class AtualizarLocalizacaoCommand : Notifiable<Notification>,  ICommand
    {
        public AtualizarLocalizacaoCommand(string nome, string descricao, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
        }


        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public string ModificadoPor { get;  set; }
      
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}