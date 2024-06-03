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
    public class AcessoControladoraQueryHandler : IAcessoControladoraQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _data;

        public AcessoControladoraQueryHandler(IMapper mapper, IUnitOfWork data)
        {
            _mapper = mapper;
            _data = data;
        }

        public async Task<IEnumerable<AcessoControladoraDTO>> ListaAcessoControladoras()
        {
            var lista = _mapper.Map<List<AcessoControladoraDTO>>(await _data.AcessoControladoras.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaAcessoControladoraGridDTO>> GridAcessoControladoras()
        {
            List<ListaAcessoControladoraGridDTO> lista = new();
            var acessos = await _data.AcessoControladoras.GetAllByGrid();

            foreach (var control in acessos)
            {
                lista.Add(new ListaAcessoControladoraGridDTO
                {
                    Id = control.Id,
                    Localizacao =control.Localizacao.Nome,
                    Setor =control.Setor.Nome,
                    Nome = control.Nome,
                    Observacao = control.Observacao,
                    ModificadoPor = control.ModificadoPor,
                    DataModificacao = control.DataModificacao,
                    Ativo = control.Ativo,
                    LocalizacaoId = control.LocalizacaoId,
                    SetorId = control.SetorId
                });
            }
            return lista;

        }
        public async Task<AcessoControladoraDTO> GetById(Guid id)
        {
            var setor = _mapper.Map<AcessoControladoraDTO>(await _data.AcessoControladoras.GetByIdAsync(id));
            return setor;

        }





    }
}
