using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AdicionarAsync(Computador computador)
        {
           await _repository.CreateAsync(computador);
        }

        public Task AtualizarAsync(Computador computador)
        {
            throw new NotImplementedException();
        }
    }
}
