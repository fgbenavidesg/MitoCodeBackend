using GestionLibros.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Persistence.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Clientes>
    {
         public void Configure(EntityTypeBuilder<Clientes> builder)
        {
            builder.Property(x => x.DNI)
                 .HasMaxLength(8);
            builder.HasIndex(x => x.DNI)
                .IsUnique();
            builder.Property(x=>x.Nombres)
                .HasMaxLength (50);
            builder.Property(x=>x.Apellidos)
                .HasMaxLength (200);

            builder.ToTable(nameof(Clientes), "Biblioteca");
        }
    }
}
