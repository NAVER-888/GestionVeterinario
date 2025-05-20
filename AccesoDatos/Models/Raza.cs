using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Raza
{
    public int id_raza { get; set; }

    public string nombre_raza { get; set; } = null!;

    public string? descripcion { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<Servicio_precio_raza> Servicio_precio_raza { get; set; } = new List<Servicio_precio_raza>();
}
