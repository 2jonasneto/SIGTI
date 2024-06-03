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
    public class ControladoraRepository : GenericRepository<Controladora>, IControladoraRepository
    {
        private SigtiContext _context;
        public ControladoraRepository(SigtiContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Controladora>> GetAllByGrid()
        {
            return await _context.Controladoras.AsNoTracking().Include(x =>x.Localizacao).Include(x => x.Setor).ToListAsync();
        }
    }
}
