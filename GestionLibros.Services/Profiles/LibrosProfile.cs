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
    public class LibrosProfile :Profile
    {
        public LibrosProfile()
        {
            CreateMap<Libros, LibroResponseDto>();//origen -destino
            CreateMap<LibroRequestDto, Libros>();
        }

    }
}
