
namespace GestionLibros.Entities
{
    public class Pedido : EntityBase
    {
        public DateTime FechaPedido { get; set; }
        public string ClienteId { get; set; } = default!;
        public string LibrosId { get; set; } = default!;

        //Propiedad(es) de navegación
        public Clientes Cliente { get; set; } = default!;
        public Libros Libro { get; set; } = default!;
    }
}
