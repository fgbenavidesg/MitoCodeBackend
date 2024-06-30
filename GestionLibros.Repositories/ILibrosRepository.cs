using GestionLibros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Repositories
{
    public interface ILibrosRepository : IRepositoryBase<Libros>
    {
        Task FinalizeAsync(string id);
    }
}
