using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Servicio_precio_raza
{
    public int id_servicio_precio { get; set; }

    public int id_servicio { get; set; }

    public int? id_raza { get; set; }

    public string? especie { get; set; }

    public decimal precio { get; set; }

    public virtual Raza? id_razaNavigation { get; set; }

    public virtual Servicio id_servicioNavigation { get; set; } = null!;
}
