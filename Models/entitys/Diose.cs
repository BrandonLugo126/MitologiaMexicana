using System;
using System.Collections.Generic;

namespace MitologiaMexicana.Models.entitys;

public partial class Diose
{
    public int Id { get; set; }

    public string NombreGeneral { get; set; } = null!;

    public string? Genero { get; set; }

    public string? Dominio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CivilizacionDio> CivilizacionDios { get; set; } = new List<CivilizacionDio>();
}
