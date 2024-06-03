using Flunt.Notifications;
using Sigti.Application.Interfaces;

namespace Sigti.Application
{
    public class RemoverImpressoraCommand :  ICommand
    {
        public Guid Id { get; set; }
        public string Modelo { get; set; }
        public RemoverImpressoraCommand(Guid id, string modelo)
        {
            this.Id = id;
            Modelo = modelo;
        }
        public RemoverImpressoraCommand()
        {
            
        }

      
    }
}
