using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigti.Core.Entities;

namespace Sigti.Data.EntityConfigure
{
    public class ControladoraConfig : IEntityTypeConfiguration<Controladora>
    {
        public void Configure(EntityTypeBuilder<Controladora> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("Varchar(100)");


            builder.HasMany(f => f.AcessoControladoras).WithOne(b => b.Controladora).OnDelete(DeleteBehavior.Restrict); ;
           


        }
    }
}
