namespace Sigti.Core.Entities
{
    public sealed class AcessoControladora : Entity
    {
        public AcessoControladora(string nome, string observacao, Guid localizacaoId, string modificadoPor, Guid setorId, string digitalId, Guid controladoraId)
        {
            Nome = nome;
            Observacao = observacao;
            LocalizacaoId = localizacaoId;
            ModificadoPor = modificadoPor;
            SetorId = setorId;
            DigitalId = digitalId;
            ControladoraId = controladoraId;
        }
        public void Atualizar(string nome, string observacao, Guid localizacaoId, string modificadoPor, Guid setorId, string digitalId, Guid controladoraId)
        {
            Nome = nome;
            Observacao = observacao;
            LocalizacaoId = localizacaoId;
            ModificadoPor = modificadoPor;
            DigitalId = digitalId;
            ControladoraId = controladoraId;
            DataModificacao = DateTime.Now;
        }
        public string Nome { get; private set; }
        public string Observacao { get; private set; }
        public string DigitalId { get; private set; }
        public Guid ControladoraId { get; private set; }
        public Guid LocalizacaoId { get; private set; }
        public Guid SetorId { get; private set; }



        public Localizacao Localizacao { get; }
        public Setor Setor { get; }
        public Controladora Controladora { get; }
    }
}
