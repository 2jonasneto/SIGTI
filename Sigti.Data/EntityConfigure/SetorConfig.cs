using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigti.Core.Entities;

namespace Sigti.Data.EntityConfigure
{
    public class SetorConfig : IEntityTypeConfiguration<Setor>
    {
        public void Configure(EntityTypeBuilder<Setor> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("Varchar(100)");


            builder.HasMany(f => f.Impressoras).WithOne(b => b.Setor).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(f => f.Computadores).WithOne(b => b.Setor).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(f => f.Controladoras).WithOne(b => b.Setor).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(f => f.AcessoControladoras).WithOne(b => b.Setor).OnDelete(DeleteBehavior.Restrict); ;

           
        }
    }
}
