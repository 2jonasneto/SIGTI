using Microsoft.EntityFrameworkCore;
using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;

namespace Sigti.Data.Repositories
{
    public class SetorRepository : GenericRepository<Setor>, ISetorRepository
    {
        private SigtiContext _context;
        public SetorRepository(SigtiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Setor>> GetAllByGrid()
        {
            return await _context.Setores.AsNoTracking().Include(x => x.Localizacao).ToListAsync();
        }
    }
}
