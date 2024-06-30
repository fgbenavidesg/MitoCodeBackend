using AutoMapper;
using GestionLibros.Dto.Request;
using GestionLibros.Dto.Response;
using GestionLibros.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Services.Profiles
{
    public class PedidoProfile :Profile
    {
        private static readonly CultureInfo culture = new("es-PE");
        public PedidoProfile()
        {
            CreateMap<PedidoRequestDto, Pedido>(); //origen-destino
            CreateMap<Pedido,PedidoResponseDto>()
                .ForMember(d=>d.Fecha,o=>o.MapFrom(x=>x.FechaPedido.ToString("D",culture)))
                .ForMember(d => d.Hora, o => o.MapFrom(x => x.FechaPedido.ToString("T", culture)))
                .ForMember(d=>d.Cliente,o=>o.MapFrom(x=>$"{x.Cliente.Nombres} {x.Cliente.Apellidos}"))
                .ForMember(d=>d.Libro, o=>o.MapFrom(x=>x.Libro.Nombre));
        }
    }
}
