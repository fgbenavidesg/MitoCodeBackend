using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLibros.Dto.Response
{
    public class PedidoResponseDto
    {
        //public DateTime FechaPedido { get; set; }
        public string Id { get; set; } = default!;
        public string Cliente { get; set; } = default!;
        public string Libro { get; set; } = default!;
        public string Fecha { get; set; } = default!;
        public string Hora { get; set; } =  default!;
        public bool Status { get; set; } = true;
    }
}
