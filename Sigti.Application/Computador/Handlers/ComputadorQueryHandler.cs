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
    public class ComputadorQueryHandler : IComputadorQueryHandler
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
            var lista = _mapper.Map<List<ComputadorDTO>>(await _data.Computadores.GetAllAsync());
            return lista;

        }
        public async Task<IEnumerable<ListaComputadorGridDTO>> GridComputadores()
        {
            List<ListaComputadorGridDTO> lista = new();
            var pcs = await _data.Computadores.GetAllByGrid();

            foreach (var pc in pcs)
            {
                lista.Add(
                    new ListaComputadorGridDTO(

                    id: pc.Id,
                    hostName: pc.HostName,
                    patrimonio: pc.Patrimonio,
                    ip: pc.Ip,
                    anydesk: pc.Anydesk,
                    processador: pc.Processador,
                    memoria: pc.Memoria,
                    disco: pc.Disco,
                    grupos: pc.Grupos,
                    ativo: pc.Ativo,
                    modificadoPor: pc.ModificadoPor,
                    dataModificacao: pc.DataModificacao,
                    sistemaOperacional: pc.SistemaOperacional,
                    ultimoUsuarioLogado: pc.UltimoUsuarioLogado,
                    setor: pc.Setor.Nome,
                    setorId: pc.SetorId,
                    localizacaoId: pc.LocalizacaoId,
                    localizacao: pc.Localizacao.Nome,
                    observacao: pc.Observacao

                ));
            }
            return lista;

        }
        public async Task<ComputadorDTO> GetById(Guid id)
        {
            var pc = _mapper.Map<ComputadorDTO>(await _data.Computadores.GetByIdAsync(id));
            return pc;

        }
        public async Task<int> GetQuantidade()
        {

            var d = await _data.Computadores.GetQuantity();

            return d;

        }




    }
}
