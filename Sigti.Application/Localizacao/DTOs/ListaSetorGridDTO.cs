using Sigti.Application.Interfaces;

namespace Sigti.Application.DTO
{
    public record ListaLocalizacaoGridDTO(DateTime dataModificacao,
       string nome, string descricao) : IDTO
    { }
}
