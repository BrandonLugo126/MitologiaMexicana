using System;
using System.Collections.Generic;

namespace MitologiaMexicana.Models.entitys;

public partial class Civilizacione
{
    public int IdCivilizacion { get; set; }

    public string Nombre { get; set; } = null!;

    public int? PeriodoInicio { get; set; }

    public int? PeriodoFin { get; set; }

    public string? Region { get; set; }

    public string? Capital { get; set; }

    public string? Lengua { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CivilizacionDio> CivilizacionDios { get; set; } = new List<CivilizacionDio>();
}
