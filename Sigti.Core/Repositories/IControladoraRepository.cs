using Sigti.Core.Entities;
using Sigti.Core.Interfaces;

namespace Sigti.Core.Repositories
{
    public interface IControladoraRepository:IGenericRepository<Controladora>
    {
        Task<List<Controladora>> GetAllByGrid();
    }
}
