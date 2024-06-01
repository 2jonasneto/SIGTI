using Flunt.Notifications;
using Flunt.Validations;
using Sigti.Application.Base;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sigti.Application
{
    public class AtualizarLocalizacaoCommand :  ICommand
    {
        public AtualizarLocalizacaoCommand(Guid id,string nome, string descricao, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
            Id = id;
        }
        public AtualizarLocalizacaoCommand()
        {
            
        }

        public Guid Id { get;  set; }
        [Required]
        [MinLength(3, ErrorMessage = "Nome deve ter mais de 3 caracteres!")]
        
        public string Nome { get;  set; }
        public string Descricao { get;  set; } = "";
        public string ModificadoPor { get;  set; }
      
      
    }
}
