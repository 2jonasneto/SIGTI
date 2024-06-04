using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application
{
    public class AtualizarAcessoControladoraCommand :  ICommand
    {
        public AtualizarAcessoControladoraCommand(Guid id, string nome, string observacao, string modificadoPor, Guid localizacaoId, Guid setorId, string digitalId, Guid controladoraId)
        {
            Nome = nome;
            Observacao = observacao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
            Id = id;
            SetorId = setorId;
            DigitalId = digitalId;
            ControladoraId = controladoraId;
        }
        public AtualizarAcessoControladoraCommand()
        {
            
        }

        public Guid Id { get;  set; }
        public string Nome { get;  set; }
        public string Observacao { get; set; } = "";
        public string DigitalId { get; set; } = string.Empty;

        public string ModificadoPor { get; set; } = "";
        public Guid LocalizacaoId { get;  set; }
        public Guid SetorId { get;  set; }
        public Guid ControladoraId { get;  set; }
      
       
    }
}
