namespace GestionLibros.Entities
{
    public class Clientes : EntityBase
    {
       
        public string Nombres { get; set; } = default!;
        public string Apellidos { get; set; } = default!;
        public string DNI {  get; set; } = default!;
        public int Edad { get; set; }
    }
}
