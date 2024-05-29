using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverImpressoraCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public RemoverImpressoraCommand(Guid id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
