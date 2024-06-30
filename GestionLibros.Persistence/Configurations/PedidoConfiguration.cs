using GestionLibros.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Persistence.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(x => x.FechaPedido)
                .HasColumnType("datetime")
                 .HasDefaultValueSql("GETDATE()");
           

            builder.ToTable(nameof(Pedido), "Biblioteca");
        }
    }
}
