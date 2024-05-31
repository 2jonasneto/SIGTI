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
    public class LocalizacaoQueryHandler : ILocalizacaoQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public LocalizacaoQueryHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<LocalizacaoDTO>> ListaLocalizacoes()
        {
            var lista = _mapper.Map<List<LocalizacaoDTO>>(await _data.Localizacoes.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaLocalizacaoGridDTO>> GridLocalizacoes()
        {
            List<ListaLocalizacaoGridDTO> lista = new();
            var setors = await _data.Localizacoes.GetAllAsync();

            foreach (var setor in setors)
            {
                lista.Add(new ListaLocalizacaoGridDTO(setor.DataModificacao, setor.Nome, setor.Descricao));
            }
            return lista;

        }
        public async Task<LocalizacaoDTO> GetById(Guid id)
        {
            var setor = _mapper.Map<LocalizacaoDTO>(await _data.Localizacoes.GetByIdAsync(id));
            return setor;

        }





    }
}
