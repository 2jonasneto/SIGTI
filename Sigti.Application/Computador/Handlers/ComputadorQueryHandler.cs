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
        public async Task<IEnumerable<ListaComputadorGridDTO>> GridComputadores()
        {
            List<ListaComputadorGridDTO> lista = new();
            var pcs =await _data.Computadores.GetAllAsync();

            foreach (var pc in pcs)
            {
                lista.Add(new ListaComputadorGridDTO(pc.DataModificacao, pc.HostName, pc.Patrimonio, pc.SetorId, pc.LocalizacaoId));
            }
            return lista;
            
        }
        public async Task<ComputadorDTO> GetById(Guid id)
        {
            var pc = _mapper.Map<ComputadorDTO>(await _data.Computadores.GetByIdAsync(id));
            return pc;

        }

        


      
    }
}
