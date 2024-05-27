using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Data.Repositories
{
    public class ImpressoraRepository : GenericRepository<Impressora>, IImpressoraRepository
    {
        public ImpressoraRepository(SigtiContext context) : base(context)
        {
        }
    }
}
