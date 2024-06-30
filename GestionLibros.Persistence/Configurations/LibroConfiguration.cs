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
    public class LibroConfiguration : IEntityTypeConfiguration<Libros>
    {
        public void Configure(EntityTypeBuilder<Libros> builder)
        {

            builder.Property(x => x.ISBN)
                .HasMaxLength(13);
            builder.Property(x => x.Autor)
                .HasMaxLength(50);
            builder.Property(x => x.Nombre)
                .HasMaxLength(50);

            builder.ToTable(nameof(Libros), "Biblioteca");
        }
    }
}
