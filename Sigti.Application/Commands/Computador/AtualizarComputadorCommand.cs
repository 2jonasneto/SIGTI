using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class AtualizarComputadorCommand : Notifiable<Notification>,  ICommand
    {
        public AtualizarComputadorCommand(string hostName, string processador, string memoria,
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
