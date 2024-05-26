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
    public class ImpressoraRepository : IImpressoraRepository
    {
        private readonly GenericRepository<Impressora> _repository;
        public ImpressoraRepository(GenericRepository<Impressora> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Impressora impressora)
        {
           await _repository.CreateAsync(impressora);
        }

        public async Task<Impressora> ByIdAsync(Guid id)
        {
           return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Impressora>> ListAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Impressora>> ListAllAsync(Expression<Func<Impressora, bool>> expression)
        {
            return await _repository.GetAllByExpressionAsync(expression);
        }

        public async Task UpdateAsync(Impressora impressora)
        {
            await _repository.UpdateAsync(impressora);
        }

    }
}
