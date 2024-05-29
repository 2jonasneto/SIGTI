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
    public class ImpressoraQueryHandler:IImpressoraQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public ImpressoraQueryHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<ImpressoraDTO>> ListaImpressoras()
        {
            var lista=_mapper.Map<List<ImpressoraDTO>>(await _data.Impressoras.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaImpressoraGridDTO>> GridImpressoras()
        {
            List<ListaImpressoraGridDTO> lista = new();
            var prints =await _data.Impressoras.GetAllAsync();

            foreach (var print in prints)
            {
                lista.Add(new ListaImpressoraGridDTO(print.DataModificacao, print.Modelo, print.Patrimonio,print.Alugado,print.SetorId, print.LocalizacaoId));
            }
            return lista;
            
        }
        public async Task<ImpressoraDTO> GetById(Guid id)
        {
            var print = _mapper.Map<ImpressoraDTO>(await _data.Impressoras.GetByIdAsync(id));
            return print;

        }

        


      
    }
}
