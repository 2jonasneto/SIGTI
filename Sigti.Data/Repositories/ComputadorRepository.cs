using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Data.Repositories
{
    public class ComputadorRepository : IComputadorRepository
    {
        private readonly GenericRepository<Computador> _repository;
        public ComputadorRepository(GenericRepository<Computador> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Computador computador)
        {
           await _repository.CreateAsync(computador);
        }

        public async Task<Computador> ByIdAsync(Guid id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Computador>> ListAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Computador>> ListAllAsync(Expression<Func<Computador, bool>> expression)
        {
            return await _repository.GetAllByExpressionAsync(expression);
        }

        public async Task UpdateAsync(Computador computador)
        {
            await _repository.UpdateAsync(computador);
        }

    }
}
