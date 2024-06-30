using AutoMapper;
using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using GestionLibros.Repositories;
using GestionLibros.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Services.Implementation
{
    public class LibrosService :ILibrosService
    {
        private readonly ILibrosRepository librosRepository;
        private readonly IMapper mapper;

        public LibrosService(ILibrosRepository librosRepository,IMapper mapper)
        {
            this.librosRepository = librosRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponseGeneric<ICollection<LibroResponseDto>>> GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<LibroResponseDto>>();
            try
            {
                var data = await librosRepository.GetAsync();
                response.Data = mapper.Map<ICollection<LibroResponseDto>>(data);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al listar los libros";
            }
            return response;
        }
        public async Task<BaseResponseGeneric<LibroResponseDto>> GetLibroAsync(string id)
        {
            var response = new BaseResponseGeneric<LibroResponseDto>();

            try
            {
                var data = await librosRepository.GetAsync(id);
                response.Data = mapper.Map<LibroResponseDto>(data);
                response.Success = data != null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al obtener el libro";
            }
            return response;
        }
        public async Task<BaseResponseGeneric<string>> AddAsync(LibroRequestDto libroRequestDto)
        {
            var response = new BaseResponseGeneric<string>();

            try
            {
                response.Data = await librosRepository.AddAsync(mapper.Map<Libros>(libroRequestDto));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al guardar el libro" +ex;
            }
            return response;
        }
        public async Task<BaseResponse> UpdateAsync(string id, LibroRequestDto libroRequestDto)
        {
            var response = new BaseResponse();

            try
            {
                var Data = await librosRepository.GetAsync(id);
                if (Data is null)
                {
                    response.ErrorMessage = $"el libro con el id {id} no fue encontrado";
                    return response;
                }
                mapper.Map(libroRequestDto, Data);
                await librosRepository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al actualizar el libro";
            }
            return response;
        }
        public async Task<BaseResponse> DeleteAsync(string id)
        {
            var response = new BaseResponse();

            try
            {
                await librosRepository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al eliminar el libro";
            }
            return response;
        }

    }
}
