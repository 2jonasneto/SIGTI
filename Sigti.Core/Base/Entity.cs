
namespace Sigti.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }=Guid.NewGuid();
        public bool Ativo { get; protected set; } = true;
        public string ModificadoPor { get; protected set; }
        public DateTime DataModificacao { get; protected set; } = DateTime.Now;
    
    }
}
