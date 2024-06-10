using Flunt.Notifications;
using Sigti.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application
{

    public class AdicionarComputadorCommand : Notifiable<Notification> , ICommand
    {
        public AdicionarComputadorCommand()
        {
            
        }
        public AdicionarComputadorCommand(string hostName, string processador, string memoria,
               string disco, string ip, string anydesk, string grupos,
               string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
               string modificadoPor, Guid setorId, Guid localizacaoId, string observacao)
        {
            HostName = hostName;
            Processador = processador;
            Memoria = memoria;
            Disco = disco;
            Ip = ip;
            Anydesk= anydesk;
            Grupos= grupos;
            UltimoUsuarioLogado = ultimoUsuarioLogado;
            Patrimonio= patrimonio;
            SistemaOperacional= sistemaOperacional;
            ModificadoPor= modificadoPor;
            SetorId= setorId;
            LocalizacaoId= localizacaoId;
            Observacao= observacao;
        }
       
        public string ModificadoPor { get; set; }
        public string HostName { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Processador { get; set; }
        public string Memoria { get; set; }
        public string Disco { get; set; }
        public string Ip { get; set; }
        public string Anydesk { get; set; }
        public string Grupos { get; set; }
        public string UltimoUsuarioLogado { get; set; }
        public string Patrimonio { get; set; }
        public string SistemaOperacional { get; set; }
        public Guid SetorId { get; set; }
        public Guid LocalizacaoId { get; set; }
        public string Observacao { get; set; }



        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
