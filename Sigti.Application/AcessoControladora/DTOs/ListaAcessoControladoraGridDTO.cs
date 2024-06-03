using Sigti.Application.Interfaces;

namespace Sigti.Application.DTO
{
    public record ListaAcessoControladoraGridDTO() : IDTO
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string ModificadoPor { get; set; } = string.Empty;
        public DateTime DataModificacao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public string DigitalId { get; set; } = string.Empty;

        public Guid LocalizacaoId { get; set; }
        public Guid SetorId { get; set; }
        public Guid ControladoraId { get; set; }
        public string Setor { get; set; } = string.Empty;
        public string Localizacao { get; set; } = string.Empty;
        public string Controladora { get; set; } = string.Empty;
    }
}
