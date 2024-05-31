using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application
{

    public class AdicionarLocalizacaoCommand : Notifiable<Notification> , ICommand
    {
        public AdicionarLocalizacaoCommand(string nome, string descricao, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
           
        }
        public AdicionarLocalizacaoCommand()
        {
            
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ModificadoPor { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
