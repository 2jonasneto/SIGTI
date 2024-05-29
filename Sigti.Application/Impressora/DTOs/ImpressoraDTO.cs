using Sigti.Application.Interfaces;
using Sigti.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.DTO
{
    public class ImpressoraDTO() : IDTO
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime DataModificacao { get; set; }
        public string Modelo { get; set; }
        public string Patrimonio { get; set; }
        public bool Alugado { get; set; }
        public Guid SetorId { get; set; }
        public Guid LocalizacaoId { get; set; }
        public string Observacao { get; set; }
        public string Ip { get; set; }
        public ETipoConexaoImpressora Conexao { get; set; }
        public ETipoImpressora Tipo { get; set; }
    }
}
