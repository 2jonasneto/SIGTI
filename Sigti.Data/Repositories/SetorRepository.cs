using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;

namespace Sigti.Data.Repositories
{
    public class SetorRepository : GenericRepository<Setor>, ISetorRepository
    {
        public SetorRepository(SigtiContext context) : base(context)
        {
        }
    }
}
