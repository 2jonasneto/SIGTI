using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Sigti.Core.Entities;
using Sigti.Core.Repositories;
using Sigti.Data.Base;
using Sigti.Data.Repositories;

namespace Sigti.Core.Interfaces
{

    public class UnitOfWork : Notifiable<Notification>, IUnitOfWork, IDisposable
    {
        public IComputadorRepository Computadores { get; private set; }
        public IImpressoraRepository Impressoras { get; private set; }
        public ISetorRepository Setores { get; private set; }
        public ILocalizacaoRepository Localizacoes { get; private set; }

        private readonly SigtiContext _context;
        private IDbContextTransaction? transaction = null;

        public UnitOfWork(SigtiContext context)
        {
            _context = context;

            Computadores = new ComputadorRepository(_context);
            Impressoras = new ImpressoraRepository(_context);
            Setores = new SetorRepository(_context);
            Localizacoes = new LocalizacaoRepository(_context);

        }
      
        public async Task<bool> Commit()
        {
            try
            {

               await _context.Database.CommitTransactionAsync();
                _context.ChangeTracker.Entries()
              .Where(e => e.Entity != null).ToList()
              .ForEach(e => e.State = EntityState.Detached);
            }
            catch (Exception e)
            {
                _context.Database.RollbackTransaction();
                _context.ChangeTracker.Entries()
              .Where(e => e.Entity != null).ToList()
              .ForEach(e => e.State = EntityState.Detached);
                AddNotification(new Notification("Commit", e.Message));
                return false;
            }
            return true;

        }

      

        public async Task<bool> Init()
        {
            try
            {
                if (_context.Database.CurrentTransaction != null)
                {
                    _context.Database.CurrentTransaction.Rollback();
                }
               await _context.Database.BeginTransactionAsync();
                return true;
            }
            catch (Exception e)
            {
                AddNotification(new Notification("Init", e.Message));
                return false;

            }

        }

        public async Task<bool> Save()
        {
            try
            {
                var d =await _context.SaveChangesAsync() > 0;

                if (!d) AddNotification(new Notification("Save", "Falha na Transação"));
                return d;
            }
            catch (Exception e)
            {

                AddNotification(new Notification("Save", $"{e.Message}\n\n{e.Source}\n {e.Message}"));
                return false;
            }
        }

        public async Task Rollback()
        {
            try
            {
               await _context.Database.RollbackTransactionAsync();

                _context.ChangeTracker.Entries()
                 .Where(e => e.Entity != null).ToList()
                 .ForEach(e => e.State = EntityState.Detached);


            }
            catch (Exception e)
            {

                AddNotification(new Notification("RoolBack", e.Message));
            }
        }

      
        public void NotificationsClear()
        {
            Clear();
        }
        public IReadOnlyCollection<Notification> GetNotifications()
        {
            return Notifications;
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }


  
}
