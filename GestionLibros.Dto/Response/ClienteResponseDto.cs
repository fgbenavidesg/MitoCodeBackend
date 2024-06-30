using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Dto.Response
{
    public class ClienteResponseDto
    {
        public string Id { get; set; } = default!;
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string DNI { get; set; } = default!;
        public int Edad { get; set; }
        public bool Status { get; set; } = true;


    }
}
