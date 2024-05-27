using Microsoft.EntityFrameworkCore;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Data.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly SigtiContext _context;
        public GenericRepository(SigtiContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

    

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.FindAsync(typeof(Guid), id);
            if (entity != null)
            {
                //This will mark the Entity State as Deleted
                _context.Remove(id);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByIdAsync(Guid id)
        {
          return await _context.Set<T>().AsNoTracking().Where(t=>t.Id==id).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {

            _context.Update(entity);
        }
    }
}
