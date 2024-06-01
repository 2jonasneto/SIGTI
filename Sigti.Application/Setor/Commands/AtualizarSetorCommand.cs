using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application
{
    public class AtualizarSetorCommand :  ICommand
    {
        public AtualizarSetorCommand(Guid id,string nome, string descricao, string modificadoPor, Guid localizacaoId)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
            Id = id;
        }
        public AtualizarSetorCommand()
        {
            
        }

        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get; set; } = "";
        public string ModificadoPor { get;  set; }
        public Guid LocalizacaoId { get;  set; }
      
       
    }
}
