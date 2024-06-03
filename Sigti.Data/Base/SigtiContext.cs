using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sigti.Core.Entities;
using System.Reflection;

namespace Sigti.Data.Base
{
    public class SigtiContext:IdentityDbContext
    {
        public SigtiContext(DbContextOptions<SigtiContext> options):base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<Localizacao>().HasData(new Localizacao("MATRIZ", "", "SYSTEM",Guid.Parse("dc3d00ff-e610-4e9c-a333-05bf70aa6c14")));
            builder.Entity<Setor>().HasData(new Setor("GERAL", "", Guid.Parse("dc3d00ff-e610-4e9c-a333-05bf70aa6c14"), "SYSTEM"));
           
            
        }
        public DbSet<Computador> Computadores { get; set; }
        public DbSet<Impressora> Impressoras { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Controladora> Controladoras { get; set; }
        public DbSet<AcessoControladora> AcessoControladoras { get; set; }
    }
}
