using AutoMapper;
using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Services.Profiles
{
    public class ClientesProfile : Profile
    {
        public ClientesProfile() {
            CreateMap<Clientes, ClienteResponseDto>();//origen -destino
            CreateMap<ClienteRequestDto, Clientes>();
        }

    }
}
