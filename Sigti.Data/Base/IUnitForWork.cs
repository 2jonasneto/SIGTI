using Microsoft.EntityFrameworkCore.Storage;
using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using Sigti.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Interfaces
{
    public interface IUnitForWork
    {//Define the Specific Repositories
        ComputadorRepository Computadores { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        Task Save();
    }
    public class UnitForWork : IUnitForWork
    {
        public ComputadorRepository Computadores { get; private set; }
        private readonly SigtiContext _context;
        private IDbContextTransaction? transaction = null;
        public UnitForWork(SigtiContext context)
        {
            _context = context;

            Computadores = new ComputadorRepository(new GenericRepository<Computador>(_context));

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
