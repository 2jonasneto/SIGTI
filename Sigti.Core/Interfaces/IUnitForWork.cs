using Sigti.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Interfaces
{
    public interface IUnitForWork
    {//Define the Specific Repositories
        IComputadorRepository Computadores { get; }
        IImpressoraRepository Impressoras { get; }
        Task<(bool success, string message)> CreateTransaction();
        Task<(bool success, string message)> Commit();
        Task<(bool success, string message)> Rollback();
        Task<(bool success, string message)> Save();
    }
}
