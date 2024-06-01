using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Application.Interfaces
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResult> Execute(T command);
        void NotificationsClear();
    }
}
