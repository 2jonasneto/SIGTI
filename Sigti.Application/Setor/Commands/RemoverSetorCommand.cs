using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverSetorCommand :  ICommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public RemoverSetorCommand()
        {
                
        }
        public RemoverSetorCommand(Guid id, string nome)
        {
            this.Id = id;
            Nome = nome;
        }


    }
}
