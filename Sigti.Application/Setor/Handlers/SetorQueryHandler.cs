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
    public class SetorQueryHandler : ISetorQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public SetorQueryHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<SetorDTO>> ListaSetores()
        {
            var lista = _mapper.Map<List<SetorDTO>>(await _data.Setores.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaSetorGridDTO>> GridSetores()
        {
            List<ListaSetorGridDTO> lista = new();
            var setors = await _data.Setores.GetAllAsync();

            foreach (var setor in setors)
            {
                lista.Add(new ListaSetorGridDTO(setor.DataModificacao, setor.Nome, setor.Descricao, setor.LocalizacaoId));
            }
            return lista;

        }
        public async Task<SetorDTO> GetById(Guid id)
        {
            var setor = _mapper.Map<SetorDTO>(await _data.Setores.GetByIdAsync(id));
            return setor;

        }





    }
}
