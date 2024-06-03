using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System.Linq.Expressions;

namespace Sigti.Core.Repositories
{
    public interface IImpressoraRepository : IGenericRepository<Impressora>
    {
        Task<List<Impressora>> GetAllByGrid();
    }
}
