using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application
{
    public class AtualizarSetorCommand : Notifiable<Notification>,  ICommand
    {
        public AtualizarSetorCommand(string nome, string descricao, string modificadoPor, Guid localizacaoId)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
        }


        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public string ModificadoPor { get;  set; }
        public Guid LocalizacaoId { get;  set; }
      
        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
