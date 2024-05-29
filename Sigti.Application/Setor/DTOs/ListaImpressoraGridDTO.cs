using Sigti.Application.Interfaces;

namespace Sigti.Application.DTO
{
    public record ListaSetorGridDTO(DateTime dataModificacao,
       string nome, string descricao, Guid localizacaoId) : IDTO
    { }
}
