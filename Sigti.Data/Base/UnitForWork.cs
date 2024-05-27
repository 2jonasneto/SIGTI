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

        public async Task<(bool success, string message)> Commit()
        {
            try
            {
                await transaction?.CommitAsync();
                return (true, "OK");
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }

        }

        public async Task<(bool success, string message)> CreateTransaction()
        {

            try
            {
                transaction = await _context.Database.BeginTransactionAsync();
                return (true, "OK");
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }

        }

        public async Task<(bool success, string message)> Rollback()
        {
            try
            {
               await transaction?.RollbackAsync();
                return (true, "OK");
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }
         
        }

        public async Task<(bool success, string message)> Save()
        {
            try
            {
             var rs=   await _context.SaveChangesAsync()>0;
                return rs? (true, "OK") : (false, "Não foi possivel salvar as alterações.");
            }
            catch (Exception ex)
            {

                return (false, ex.Message);
            }
            
        }
    }
}
