﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Data.EntityConfigure
{
    public class ImpressoraConfig : IEntityTypeConfiguration<Impressora>
    {
        public void Configure(EntityTypeBuilder<Impressora> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Modelo).IsRequired().HasColumnType("Varchar(150)");
            builder.Property(x => x.Observacao).IsRequired().HasColumnType("Varchar(300)");
          
            builder.Property(x => x.Patrimonio).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(x => x.Ip).IsRequired().HasColumnType("Varchar(20)");


           

        }
    }
}
