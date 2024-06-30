using GestionLibros.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestionLibros.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<Clientes>().Property(x => x.DNI).HasMaxLength(8);

        }

        //Entities to toble
       // public DbSet<Clientes> Clientes { get; set; }
    }
}
