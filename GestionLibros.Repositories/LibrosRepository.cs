using GestionLibros.Entities;
using GestionLibros.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Repositories
{
    public class LibrosRepository : RepositoryBase<Libros>, ILibrosRepository
    {
        public LibrosRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task FinalizeAsync(string id)
        {
            var libro = await GetAsync(id);
            if (libro is not null)
            {
                libro.Status = false;
                await UpdateAsync();
            }
        }
        public override async Task<string> AddAsync(Libros libros)
        {
            var nextNumber = await dbContext.Set<Libros>().CountAsync() + 1;
            libros.Id = $"LIB{nextNumber:000000}";
            await dbContext.AddAsync(libros);
            await dbContext.SaveChangesAsync();
            return libros.Id;
        }

    }
}
