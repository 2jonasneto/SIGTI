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

    public class AdicionarAcessoControladoraCommand : ICommand
    {
        public AdicionarAcessoControladoraCommand(string nome, string observacao, string modificadoPor, Guid localizacaoId, Guid setorId, string digitalId, Guid controladoraId)
        {
            Nome = nome;
            Observacao = observacao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
            SetorId = setorId;
            DigitalId = digitalId;
            ControladoraId = controladoraId;
        }
        public AdicionarAcessoControladoraCommand()
        {
            
        }
        public string Nome { get; set; }
        public string Observacao { get; set; } = "";
        public string DigitalId { get; set; } = "";
        public string ModificadoPor { get; set; }
        public Guid LocalizacaoId { get; set; }
        public Guid SetorId { get; set; }
        public Guid ControladoraId { get; set; }

      
    }
}
