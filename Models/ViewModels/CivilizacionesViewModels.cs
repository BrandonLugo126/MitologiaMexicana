namespace MitologiaMexicana.Models.ViewModels
{
    public class CivilizacionesViewModels
    {
        public string Nombre { get; set; } = null!;

        public string Periodo { get; set; }  = null!;

        public string? Region { get; set; }

        public string? Capital { get; set; }

        public string? Lengua { get; set; }

        public string? Descripcion { get; set; }
    }
    public class CivilizacionModel 
    {
        public int Id { get; set; }

        public string Nombre { get; set; } =null!;
        public string Descripcion { get; set; } = null!;
    }
}
