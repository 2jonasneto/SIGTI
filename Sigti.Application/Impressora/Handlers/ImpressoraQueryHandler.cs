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
    public class ImpressoraQueryHandler : IImpressoraQueryHandler
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
            var lista = _mapper.Map<List<ImpressoraDTO>>(await _data.Impressoras.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaImpressoraGridDTO>> GridImpressoras()
        {
            List<ListaImpressoraGridDTO> lista = new();
            var prints = await _data.Impressoras.GetAllByGrid();

            foreach (var print in prints)
            {
                lista.Add(new ListaImpressoraGridDTO
                {
                    Modelo = print.Modelo,
                    Patrimonio = print.Patrimonio,
                    Alugado = print.Alugado,
                    AlugadoStr = print.Alugado ? "SIM" : "NÃO",
                    Setor = print.Setor.Nome,
                    SetorId = print.SetorId,
                    Localizacao = print.Localizacao.Nome,
                    LocalizacaoId = print.LocalizacaoId,
                    Observacao = print.Observacao,
                    Tipo = print.Tipo,
                    Ativo = print.Ativo,
                    Ip = print.Ip,
                    ModificadoPor = print.ModificadoPor,
                    DataModificacao = print.DataModificacao,
                    Conexao = print.Conexao,
                    Id = print.Id
                });
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
