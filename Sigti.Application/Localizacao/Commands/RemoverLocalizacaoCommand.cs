using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverLocalizacaoCommand : Notifiable<Notification>, ICommand
    {
        public Guid Id { get; set; }
        public RemoverLocalizacaoCommand(Guid id)
        {
            this.Id = id;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
