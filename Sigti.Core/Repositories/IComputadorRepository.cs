using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Repositories
{
    public interface IComputadorRepository
    {
        Task AddAsync(Computador computador);
        Task UpdateAsync(Computador computador);
        Task<IEnumerable<Computador>> ListAllAsync();
        Task<IEnumerable<Computador>> ListAllAsync(Expression<Func<Computador,bool>> expression);
        Task<Computador> ByIdAsync(Guid id);
    }
}
