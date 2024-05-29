using Sigti.Application.Interfaces;

namespace Sigti.Application.DTO
{
    public record ListaImpressoraGridDTO(DateTime dataModificacao,
       string modelo, string patrimonio,bool alugado, Guid setorId, Guid localizacaoId) : IDTO
    { }
}
