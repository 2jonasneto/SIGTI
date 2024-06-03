using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application
{
    public class AtualizarControladoraCommand :  ICommand
    {
        public AtualizarControladoraCommand(Guid id, string nome, string descricao, string modificadoPor, Guid localizacaoId, Guid setorId)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
            Id = id;
            SetorId = setorId;
        }
        public AtualizarControladoraCommand()
        {
            
        }

        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get; set; } = "";
        public string ModificadoPor { get;  set; }
        public Guid LocalizacaoId { get;  set; }
        public Guid SetorId { get;  set; }
      
       
    }
}
