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
    public class ControladoraQueryHandler : IControladoraQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public ControladoraQueryHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<ControladoraDTO>> ListaControladoras()
        {
            var lista = _mapper.Map<List<ControladoraDTO>>(await _data.Controladoras.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaControladoraGridDTO>> GridControladoras()
        {
            List<ListaControladoraGridDTO> lista = new();
            var controladoras = await _data.Controladoras.GetAllByGrid();

            foreach (var control in controladoras)
            {
                lista.Add(new ListaControladoraGridDTO
                {
                    Id = control.Id,
                    Localizacao =control.Localizacao.Nome,
                    Setor =control.Setor.Nome,
                    Nome = control.Nome,
                    Descricao = control.Descricao,
                    ModificadoPor = control.ModificadoPor,
                    DataModificacao = control.DataModificacao,
                    Ativo = control.Ativo,
                    LocalizacaoId = control.LocalizacaoId,
                    SetorId = control.SetorId
                });
            }
            return lista;

        }
        public async Task<ControladoraDTO> GetById(Guid id)
        {
            var setor = _mapper.Map<ControladoraDTO>(await _data.Controladoras.GetByIdAsync(id));
            return setor;

        }





    }
}
