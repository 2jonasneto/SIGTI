using Flunt.Notifications;
using Sigti.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Core.Interfaces
{
    public interface IUnitOfWork
    {//Define the Specific Repositories
        IComputadorRepository Computadores { get; }
        IImpressoraRepository Impressoras { get; }
        ILocalizacaoRepository Localizacoes { get; }
        ISetorRepository Setores { get; }
        Task<bool> Init();
        Task<bool> Commit();
        Task Rollback();
        Task<bool> Save();


        IReadOnlyCollection<Notification> GetNotifications();
        void NotificationsClear();
    }
}
