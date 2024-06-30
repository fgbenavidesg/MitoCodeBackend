using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Services.Interface
{
    public interface ILibrosService
    {
        Task<BaseResponseGeneric<ICollection<LibroResponseDto>>> GetAsync();
        Task<BaseResponseGeneric<LibroResponseDto>> GetLibroAsync(string id);
        Task<BaseResponseGeneric<string>> AddAsync(LibroRequestDto libroRequestDto);
        Task<BaseResponse> UpdateAsync(string id, LibroRequestDto libroRequestDto);
        Task<BaseResponse> DeleteAsync(string id);
    }
}
