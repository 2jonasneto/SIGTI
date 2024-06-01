using Sigti.Application.Interfaces;

namespace Sigti.Application.DTO
{
    public record ListaSetorGridDTO() : IDTO
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public Guid LocalizacaoId { get; set; }
        public LocalizacaoDTO Localizacao { get; set; }
    }
}
