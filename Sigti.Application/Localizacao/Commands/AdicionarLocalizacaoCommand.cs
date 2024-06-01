using Flunt.Notifications;
using Sigti.Application.Interfaces;
using Sigti.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application
{

    public class AdicionarLocalizacaoCommand :  ICommand
    {
        public AdicionarLocalizacaoCommand(string nome, string descricao, string modificadoPor)
        {
            Nome = nome;
            Descricao = descricao;
            ModificadoPor = modificadoPor;
           
        }
        public AdicionarLocalizacaoCommand()
        {
            
        }


        [Required(ErrorMessage ="Campo nome é obrigatório!")]
        [MinLength(3, ErrorMessage = "Nome deve ter mais de 3 caracteres!")]
        public string Nome { get; set; }
        public string Descricao { get; set; } = "";
        public string ModificadoPor { get; set; }

    
    }
}
