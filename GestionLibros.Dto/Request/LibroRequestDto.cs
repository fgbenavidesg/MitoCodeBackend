using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Dto.Request
{
    public class LibroRequestDto
    {
        public string Nombre { get; set; } = default!;
        public string Autor { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public bool Status { get; set; } = true;
    }
}
