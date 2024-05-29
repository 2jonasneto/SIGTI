using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sigti.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigti.Data.EntityConfigure
{
    public class ComputadorConfig : IEntityTypeConfiguration<Computador>
    {
        public void Configure(EntityTypeBuilder<Computador> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Disco).IsRequired().HasColumnType("Varchar(150)");
            builder.Property(x => x.Memoria).IsRequired().HasColumnType("Varchar(150)");
            builder.Property(x => x.Processador).IsRequired().HasColumnType("Varchar(150)");
            builder.Property(x => x.Grupos).IsRequired().HasColumnType("Varchar(150)");
            builder.Property(x => x.HostName).IsRequired().HasColumnType("Varchar(150)");
            builder.Property(x => x.Observacao).IsRequired().HasColumnType("Varchar(300)");
            builder.Property(x => x.SistemaOperacional).IsRequired().HasColumnType("Varchar(100)");
            builder.Property(x => x.Patrimonio).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(x => x.Ip).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(x => x.Anydesk).IsRequired().HasColumnType("Varchar(20)");
            builder.Property(x => x.UltimoUsuarioLogado).IsRequired().HasColumnType("Varchar(50)");

        }
    }
}
