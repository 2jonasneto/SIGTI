using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverComputadorCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public RemoverComputadorCommand( Guid id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
