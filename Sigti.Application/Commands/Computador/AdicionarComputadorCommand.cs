using Flunt.Notifications;
using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application
{

    public class AdicionarComputadorCommand : Notifiable<Notification> , ICommand
    {
        public AdicionarComputadorCommand(string hostName, string processador, string memoria,
               string disco, string ip, string anydesk, string grupos,
               string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
               string modificadoPor, Guid setorId, Guid localizacaoId, string observacao)
        {
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
