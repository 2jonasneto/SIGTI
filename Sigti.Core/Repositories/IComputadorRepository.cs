using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Repositories
{
    public interface IComputadorRepository
    {
        Task AdicionarAsync(Computador computador);
        Task AtualizarAsync(Computador computador);
    }
}
