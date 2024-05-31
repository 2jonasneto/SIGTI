using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverLocalizacaoCommand : Notifiable<Notification>, ICommand
    {
        public RemoverLocalizacaoCommand()
        {
            
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public RemoverLocalizacaoCommand(Guid id, string nome)
        {
            this.Id = id;
            Nome = nome;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
