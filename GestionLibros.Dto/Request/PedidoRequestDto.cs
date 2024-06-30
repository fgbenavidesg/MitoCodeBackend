
namespace GestionLibros.Dto.Request
{
    public class PedidoRequestDto
    {
        public DateTime FechaPedido { get; set; }
        public string ClienteId { get; set; } = default!;
        public string LibrosId { get; set; } = default!;
    }
}
