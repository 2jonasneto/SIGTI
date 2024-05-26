using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System.Linq.Expressions;

namespace Sigti.Core.Repositories
{
    public interface IImpressoraRepository
    {
        Task AddAsync(Impressora impressora);
        Task UpdateAsync(Impressora impressora);
        Task<IEnumerable<Impressora>> ListAllAsync();
        Task<IEnumerable<Impressora>> ListAllAsync(Expression<Func<Impressora, bool>> expression);
        Task<Impressora> ByIdAsync(Guid id);
    }
}
