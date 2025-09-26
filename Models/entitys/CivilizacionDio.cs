using System;
using System.Collections.Generic;

namespace MitologiaMexicana.Models.entitys;

public partial class CivilizacionDio
{
    public int Id { get; set; }

    public int IdCivilizacion { get; set; }

    public int IdDios { get; set; }

    public string NombreLocal { get; set; } = null!;

    public virtual Civilizacione IdCivilizacionNavigation { get; set; } = null!;

    public virtual Diose IdDiosNavigation { get; set; } = null!;
}
