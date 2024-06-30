using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Services.Interface
{
    public interface IPedidoService
    {
        Task<BaseResponseGeneric<string>> AddAsync(PedidoRequestDto pedidoRequestDto);

        Task<BaseResponseGeneric<ICollection<PedidoResponseDto>>> GetAsync(string dni);
    }
}
