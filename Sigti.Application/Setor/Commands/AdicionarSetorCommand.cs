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

    public class AdicionarSetorCommand : ICommand
    {
        public AdicionarSetorCommand(string nome, string descricao, string modificadoPor, Guid localizacaoId)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            LocalizacaoId = localizacaoId;
        }
        public AdicionarSetorCommand()
        {
            
        }
        public string Nome { get; set; }
        public string Descricao { get; set; } = "";
        public string ModificadoPor { get; set; }
        public Guid LocalizacaoId { get; set; }

      
    }
}
