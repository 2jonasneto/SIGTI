using Sigti.Application.DTO;

namespace Sigti.Web.Services
{
    public interface IComputadorService
    {
        Task<List<ListaComputadorGridDTO>> GetComputadores();
    }
}
