using Sigti.Application.Interfaces;
using Sigti.Core.Enums;

namespace Sigti.Application.DTO
{
    public class ListaImpressoraGridDTO() : IDTO
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Modelo { get; set; }
        public string Patrimonio { get; set; }
        public bool Alugado { get; set; }
        public string AlugadoStr { get; set; }
        public string Setor { get; set; }
        public Guid SetorId { get; set; }
        public string Localizacao { get; set; }
        public Guid LocalizacaoId { get; set; }
        public string Observacao { get; set; }
        public string Ip { get; set; }
        public ETipoConexaoImpressora Conexao { get; set; }
        public ETipoImpressora Tipo { get; set; }

    }
}
