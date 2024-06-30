using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Repositories
{
    public interface IPedidoRepository :IRepositoryBase<Pedido>
    {
        Task CreateTransactionAsync();
        Task RollBackAsync();

        Task<ICollection<PedidoResponseDto>> GetPedidosDNIAsync(string dni);

    }
}
