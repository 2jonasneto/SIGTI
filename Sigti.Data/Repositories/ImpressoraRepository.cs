using Microsoft.EntityFrameworkCore;
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
        private readonly SigtiContext _context;

        public ImpressoraRepository(SigtiContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Impressora>> GetAllByGrid()
        {
            return await _context.Impressoras.AsNoTracking().Include(x => x.Localizacao).Include(x => x.Setor).ToListAsync();
        }
    }
}
