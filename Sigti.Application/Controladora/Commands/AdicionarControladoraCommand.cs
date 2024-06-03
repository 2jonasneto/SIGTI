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

    public class AdicionarControladoraCommand : ICommand
    {
        public AdicionarControladoraCommand(string nome, string descricao, string modificadoPor, Guid localizacaoId, Guid setorId)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
            SetorId = setorId;
        }
        public AdicionarControladoraCommand()
        {
            
        }
        public string Nome { get; set; }
        public string Descricao { get; set; } = "";
        public string ModificadoPor { get; set; }
        public Guid LocalizacaoId { get; set; }
        public Guid SetorId { get; set; }

      
    }
}
