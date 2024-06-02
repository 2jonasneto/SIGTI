using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class AtualizarComputadorCommand : Notifiable<Notification>,  ICommand
    {
        public AtualizarComputadorCommand()
        {
            
        }
        public AtualizarComputadorCommand(Guid id,string hostName, string processador, string memoria,
               string disco, string ip, string anydesk, string grupos,
               string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
               string modificadoPor, Guid setorId, Guid localizacaoId, string observacao)
        {
            Id = id;
            HostName = hostName;
            Processador = processador;
            Memoria = memoria;
            Disco = disco;
            Ip = ip;
            Anydesk = anydesk;
            Grupos = grupos;
            UltimoUsuarioLogado = ultimoUsuarioLogado;
            Patrimonio = patrimonio;
            SistemaOperacional = sistemaOperacional;
            ModificadoPor = modificadoPor;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
        }

        public Guid Id { get; set; }
        public string ModificadoPor { get; set; }
        public string HostName { get; set; }
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
