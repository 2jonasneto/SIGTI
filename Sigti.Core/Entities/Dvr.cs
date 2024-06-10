namespace Sigti.Core.Entities
{
    public sealed class Dvr : Entity
    {
        public Dvr(string ip, string nome, string usuario, string senha, string serial,
            string mac, string porta, Guid setorId, Guid localizacaoId, string observacao, string modificadoPor)
        {
            Ip = ip;
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            Serial = serial;
            Mac = mac;
            Porta = porta;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            ModificadoPor = modificadoPor;
        }
        public void Atualizar(string ip, string nome, string usuario, string senha, string serial,
            string mac, string porta, Guid setorId, Guid localizacaoId, string observacao, string modificadoPor)
        {
            Ip = ip;
            Nome = nome;
            Usuario = usuario;
            Senha = senha;
            Serial = serial;
            Mac = mac;
            Porta = porta;
            SetorId = setorId;
            LocalizacaoId = localizacaoId;
            Observacao = observacao;
            ModificadoPor = modificadoPor;
        }
        public string Ip { get; private set; }
        public string Nome { get; private set; }
        public string Usuario { get; private set; }
        public string Senha { get; private set; }
        public string Serial { get; private set; }
        public string Mac { get; private set; }
        public string Porta { get; private set; }
        public Guid SetorId { get; private set; }
        public Guid LocalizacaoId { get; private set; }
        public string Observacao { get; private set; }




        public Setor Setor { get; set; }
        public Localizacao Localizacao { get; set; }
    }
}
