namespace GestionLibros.Entities
{
    public class Libros : EntityBase
    {
        public string Nombre { get; set; } = default!;
        public string Autor { get; set; } = default!;
        public string ISBN { get; set; } = default!;

    }
}
