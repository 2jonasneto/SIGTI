using Microsoft.EntityFrameworkCore;
using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;

namespace Sigti.Data.Repositories
{
    public class AcessoControladoraRepository : GenericRepository<AcessoControladora>, IAcessoControladoraRepository
    {
        private SigtiContext _context;
        public AcessoControladoraRepository(SigtiContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<AcessoControladora>> GetAllByGrid()
        {
            return await _context.AcessoControladoras.AsNoTracking().Include(x => x.Localizacao).Include(x => x.Setor).Include(x=>x.Controladora).ToListAsync();
        }
    }
}
