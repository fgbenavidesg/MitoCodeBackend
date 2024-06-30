using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Services.Interface
{
    public interface IClientesService
    {
        Task<BaseResponseGeneric<ICollection<ClienteResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<ClienteResponseDto>> GetClienteAsync(string id);
        Task<BaseResponseGeneric<string>> AddAsync(ClienteRequestDto clienteRequestDto);
        Task<BaseResponse> UpdateAsync(string id, ClienteRequestDto clienteRequestDto);
        Task <BaseResponse>DeleteAsync(string id);
    }
}
