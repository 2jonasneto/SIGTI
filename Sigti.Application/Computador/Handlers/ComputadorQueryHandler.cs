using AutoMapper;
using Sigti.Application.DTO;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Handlers
{
    public class ComputadorQueryHandler:IComputadorQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public ComputadorQueryHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<ComputadorDTO>> ListaCmputadores()
        {
            var lista=_mapper.Map<List<ComputadorDTO>>(await _data.Computadores.GetAllAsync());
            return lista;

        }
        public async Task<ComputadorDTO> GetById(Guid id)
        {
            var pc = _mapper.Map<ComputadorDTO>(await _data.Computadores.GetByIdAsync(id));
            return pc;

        }

        

        public Task<IEnumerable<ComputadorDTO>> GetByQuery()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ComputadorDTO>> GetByQuery(Expression<Func<Computador, bool>> query)
        {
            throw new NotImplementedException();
        }
    }
}
