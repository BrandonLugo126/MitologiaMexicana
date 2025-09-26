using System.ComponentModel.DataAnnotations.Schema;

namespace MitologiaMexicana.Models.ViewModels
{
    public class DiosesViewModel
    {
        public string Civilizacion { get; set; } = null!;
        public string Dios { get; set; } = "";
        public List<string> civilizaciones { get; set; } = new();
        public List<DiosModel> Dioses { get; set; } = new();

    }   
    public class DiosModel    
    {
        public int Id { get; set; } 
        public string NombreGeneral { get; set; } = null!;

        public string Civilizacion { get; set; } = null!;
        public string? Genero { get; set; }

        public string? Dominio { get; set; }
        public string? Descripcion { get; set; }
    }
}
