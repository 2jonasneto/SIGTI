using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverAcessoControladoraCommand :  ICommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public RemoverAcessoControladoraCommand()
        {
                
        }
        public RemoverAcessoControladoraCommand(Guid id, string nome)
        {
            this.Id = id;
            Nome = nome;
        }


    }
}
