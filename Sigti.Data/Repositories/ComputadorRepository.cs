using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Sigti.Core.Entities;
using Sigti.Core.Interfaces;
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
    public class ComputadorRepository : GenericRepository<Computador>, IComputadorRepository
    {
        private SigtiContext _context;
        public ComputadorRepository(SigtiContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Computador>> GetAllByGrid()
        {
            return await _context.Computadores.AsNoTracking().Include(x =>x.Localizacao).Include(x => x.Setor).ToListAsync();
        }
    } 
}
