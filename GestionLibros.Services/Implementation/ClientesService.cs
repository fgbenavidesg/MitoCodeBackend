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
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IMapper mapper;

        public ClientesService(IClientesRepository clientesRepository,IMapper mapper)
        {
            this.clientesRepository = clientesRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponseGeneric<ICollection<ClienteResponseDto>>>GetAsync()
        {
            var response = new BaseResponseGeneric<ICollection<ClienteResponseDto>>();
            try
            {
                var data = await clientesRepository.GetAsync();
                response.Data = mapper.Map<ICollection<ClienteResponseDto>>(data);
                response.Success=true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al listar los clientes";
            }
            return response;

        }
        public async Task<BaseResponseGeneric<ClienteResponseDto>> GetClienteAsync(string id)
        {
            var response = new BaseResponseGeneric<ClienteResponseDto>();

            try
            {
                var data = await clientesRepository.GetAsync(id);
                response.Data = mapper.Map<ClienteResponseDto>(data);
                response.Success = data!= null;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al obtener el cliente";
            }
            return response;
        }
        public async Task<BaseResponseGeneric<string>> AddAsync(ClienteRequestDto clienteRequestDto)
        {
            var response = new BaseResponseGeneric<string>();

            try
            {
                response.Data = await clientesRepository.AddAsync(mapper.Map<Clientes>(clienteRequestDto));
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al guardar el cliente";
            }
            return response;
        }

        public async Task<BaseResponse> UpdateAsync(string id, ClienteRequestDto clienteRequestDto)
        {
            var response = new BaseResponse();

            try
            {
                var Data = await clientesRepository.GetAsync(id);
                if(Data is null)
                {
                    response.ErrorMessage = $"el cliente con el id {id} no fue encontrado";
                    return response;
                }
                mapper.Map(clienteRequestDto, Data);
                await clientesRepository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al actualizar el cliente";
            }
            return response;
        }
        public async Task<BaseResponse> DeleteAsync(string id)
        {
            var response = new BaseResponse();

            try
            {
                await clientesRepository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "ocurrio un error al eliminar el cliente";
            }
            return response;
        }

    }
}
