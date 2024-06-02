using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverComputadorCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Hostname { get; set; }
        public RemoverComputadorCommand(Guid id, string hostname)
        {
            this.Id = id;
            Hostname = hostname;
        }
        public RemoverComputadorCommand()
        {
            
        }
     
    }
}
