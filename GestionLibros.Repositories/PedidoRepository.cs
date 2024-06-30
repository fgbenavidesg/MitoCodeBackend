using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using GestionLibros.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateTransactionAsync()
        {
           await dbContext.Database.BeginTransactionAsync(IsolationLevel.Serializable);
        }

        public async Task RollBackAsync()
        {
            await dbContext.Database.RollbackTransactionAsync();
        }
        public override async Task<string> AddAsync(Pedido pedido)
        {
            var nextNumber = await dbContext.Set<Pedido>().CountAsync() + 1;
            pedido.Id = $"PED{nextNumber:000000}";
            await dbContext.AddAsync(pedido);

            return pedido.Id;
        }
        public override async Task UpdateAsync()
        {
            await dbContext.Database.CommitTransactionAsync();
            await base.UpdateAsync();
        }
        
        public async Task<ICollection<PedidoResponseDto>> GetPedidosDNIAsync(string dni)
        {
            var queryable = dbContext.Set<Pedido>()
            .Include(x => x.Cliente)
            .Include(x => x.Libro)
            .Where(x => x.Cliente.DNI == dni)
            .AsNoTracking()
            .IgnoreQueryFilters()
            .Select(x => new PedidoResponseDto
            {
                Id = x.Id,
                Fecha=x.FechaPedido.ToShortDateString(),
                Hora=x.FechaPedido.ToShortTimeString(),
                Cliente= $"{x.Cliente.Nombres} {x.Cliente.Apellidos}",
                Libro= x.Libro.Nombre,
                Status= x.Status,
            })
            .AsQueryable();

            return await queryable.ToListAsync();
        }
    }
}
