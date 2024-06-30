using GestionLibros.Entities;
using GestionLibros.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GestionLibros.Repositories
{
    public class ClientesRepository : RepositoryBase<Clientes>, IClientesRepository
    {

        public ClientesRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<string> AddAsync(Clientes clientes)
        {
            var nextNumber = await dbContext.Set<Clientes>().CountAsync() + 1;
            clientes.Id = $"CLI{nextNumber:000000}";
            await dbContext.AddAsync(clientes);
            await dbContext.SaveChangesAsync();
            return clientes.Id;
        }

    }
}
