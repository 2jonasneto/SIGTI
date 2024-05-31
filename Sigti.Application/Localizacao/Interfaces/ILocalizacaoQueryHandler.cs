using Sigti.Application.DTO;
using Sigti.Application.Interfaces;
using Sigti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Interfaces
{
    public interface ILocalizacaoQueryHandler
    {
        Task<IEnumerable<LocalizacaoDTO>> ListaLocalizacoes();
        Task<IEnumerable<ListaLocalizacaoGridDTO>> GridLocalizacoes();

    }
}
