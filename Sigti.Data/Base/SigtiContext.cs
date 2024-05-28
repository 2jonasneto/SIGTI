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
        }
        public DbSet<Computador> Computadores { get; set; }
    }
}
