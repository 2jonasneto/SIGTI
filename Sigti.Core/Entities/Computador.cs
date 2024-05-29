namespace Sigti.Core.Entities
{
    public sealed class Computador:Entity
    {
        public Computador(string hostName, string processador, string memoria,
            string disco, string ip, string anydesk, string grupos,
            string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional,
            string modificadoPor, Guid setorId, Guid localizacaoId, string observacao)
        {
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
        public void Atualizar(string hostName, string processador, string memoria,
           string disco, string ip, string anydesk, string grupos,
           string ultimoUsuarioLogado, string patrimonio, string sistemaOperacional, 
           string modificadoPor, Guid setorId, Guid localizacaoId, string observacao)
        {
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


        public string HostName { get; private set; }
        public string Processador { get; private set; }
        public string Memoria { get; private set; }
        public string Disco { get; private set; }
        public string Ip { get; private set; }
        public string Anydesk { get; private set; }
        public string Grupos { get; private set; }
        public string UltimoUsuarioLogado { get; private set; }
        public string Patrimonio { get; private set; }
        public string SistemaOperacional { get; private set; }
        public Guid SetorId { get; private set; }
        public Guid LocalizacaoId { get; private set; }
        public string Observacao { get; private set; }


        public Setor Setor { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}
