using Sigti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAllAsync(Guid id);
        Task<IEnumerable<T>> GetAllByIdAsync(Guid id);
        Task<T> GetByIdAsync(Guid id);
    }
}
