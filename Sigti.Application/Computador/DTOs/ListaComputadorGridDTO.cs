using Sigti.Application.Interfaces;

namespace Sigti.Application.DTO
{
    public record ListaComputadorGridDTO(DateTime dataModificacao,
       string hostName, string patrimonio, Guid setorId, Guid localizacaoId) : IDTO
    { }
}
