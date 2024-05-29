using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverSetorCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public RemoverSetorCommand(Guid id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
