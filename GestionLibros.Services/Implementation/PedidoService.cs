using AutoMapper;
using Azure.Core;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionLibros.Services.Implementation
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IClientesRepository clientesRepository;
        private readonly ILibrosRepository librosRepository;
        private readonly IMapper mapper;

        public PedidoService(IPedidoRepository pedidoRepository,IClientesRepository clientesRepository,ILibrosRepository librosRepository, IMapper mapper)
        {
            this.pedidoRepository = pedidoRepository;
            this.clientesRepository = clientesRepository;
            this.librosRepository = librosRepository;
            this.mapper = mapper;
        }
        public async Task<BaseResponseGeneric<string>> AddAsync(PedidoRequestDto pedidoRequestDto)
        {
           var response = new BaseResponseGeneric<string>();
            try
            {
                await pedidoRepository.CreateTransactionAsync();
                var pedido = mapper.Map<Pedido> (pedidoRequestDto);

                var cliente = await clientesRepository.GetAsync(pedidoRequestDto.ClienteId);
                if (cliente is null)
                    throw new Exception($"El cliente con el Id {pedidoRequestDto.ClienteId} no existe.");
                if(cliente.Status == false)
                    throw new Exception($"El cliente con el Id {pedidoRequestDto.ClienteId} esta desabilitado.");

                var libro = await librosRepository.GetAsync(pedidoRequestDto.LibrosId);
                if (libro is null)
                    throw new Exception($"El libro con el Id {pedidoRequestDto.LibrosId} no existe.");
                if (libro.Status == false)
                    throw new Exception($"El libro con el Id {pedidoRequestDto.LibrosId} no se encuentra disponible.");

                await pedidoRepository.AddAsync(pedido);
                await librosRepository.FinalizeAsync(libro.Id);
                await pedidoRepository.UpdateAsync();
                response.Data = pedido.Id;
                response.Success=true;
            }
            catch (InvalidOperationException ex)
            {
                await pedidoRepository.RollBackAsync();
                response.ErrorMessage = ex.Message;
            }
            catch (Exception)
            {
                await pedidoRepository.RollBackAsync();
                response.ErrorMessage = "Error al Registrar un Pedido";
            }
            return response;
        }

        public  async Task<BaseResponseGeneric<ICollection<PedidoResponseDto>>> GetAsync(string dni)
        {
            var response = new BaseResponseGeneric<ICollection<PedidoResponseDto>>();
            try
            {
                var pedido = await pedidoRepository.GetPedidosDNIAsync(dni);
                response.Data = mapper.Map<ICollection<PedidoResponseDto>>(pedido);
                response.Success = true;
            }
            catch (Exception)
            {
                response.ErrorMessage = "Error al obtener el pedido";
            }
            return response;
        }
    }
}
