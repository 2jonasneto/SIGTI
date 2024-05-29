
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigti.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }=Guid.NewGuid();
        public bool Ativo { get; protected set; } = true;
        [Column("Varchar(50)")]
        public string ModificadoPor { get; protected set; }
        public DateTime DataModificacao { get; protected set; } = DateTime.Now;
    
    }
}
