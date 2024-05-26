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
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task Save();
    }
}
