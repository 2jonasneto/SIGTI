using Microsoft.EntityFrameworkCore.Storage;
using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using Sigti.Data.Repositories;

namespace Sigti.Core.Interfaces
{
    public class UnitForWork : IUnitForWork
    {
        public IComputadorRepository Computadores { get; private set; }
        public IImpressoraRepository Impressoras { get; private set; }
        private readonly SigtiContext _context;
        private IDbContextTransaction? transaction = null;
        public UnitForWork(SigtiContext context)
        {
            _context = context;

            Computadores = new ComputadorRepository(new GenericRepository<Computador>(_context));
            Impressoras = new ImpressoraRepository(new GenericRepository<Impressora>(_context));

        }

        public void Commit()
        {
            transaction?.Commit();
        }

        public void CreateTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Rollback()
        {
            transaction?.Rollback();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
