using Sigti.Core.Entities;
using Sigti.Core.Interfaces;

namespace Sigti.Core.Repositories
{
    public interface ISetorRepository:IGenericRepository<Setor>
    {
        Task<List<Setor>> GetAllByGrid();
    
    }
}
