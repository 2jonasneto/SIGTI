﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigti.Core.Entities;

namespace Sigti.Data.EntityConfigure
{
    public class LocalizacaoConfig : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("Varchar(50)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("Varchar(100)");



            builder.HasMany(f => f.Impressoras).WithOne(b => b.Localizacao).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(f => f.Computadores).WithOne(b => b.Localizacao).OnDelete(DeleteBehavior.Restrict); ;
            builder.HasMany(f => f.Setores).WithOne(b => b.Localizacao).HasForeignKey(k=>k.LocalizacaoId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}