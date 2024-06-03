using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverControladoraCommand :  ICommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public RemoverControladoraCommand()
        {
                
        }
        public RemoverControladoraCommand(Guid id, string nome)
        {
            this.Id = id;
            Nome = nome;
        }


    }
}
