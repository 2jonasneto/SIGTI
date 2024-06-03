using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigti.Core.Entities;

namespace Sigti.Data.EntityConfigure
{
    public class AcessoControladoraConfig : IEntityTypeConfiguration<AcessoControladora>
    {
        public void Configure(EntityTypeBuilder<AcessoControladora> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.DigitalId).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(x => x.Observacao).IsRequired().HasColumnType("Varchar(200)");


          

           
        }
    }
}
