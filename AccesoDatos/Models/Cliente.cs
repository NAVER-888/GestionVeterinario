using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Cliente
{
    public int id_cliente { get; set; }

    public string nombre { get; set; } = null!;

    public string apellido { get; set; } = null!;

    public string? direccion { get; set; }

    public string? telefono { get; set; }

    public string? email { get; set; }

    public DateTime? fecha_registro { get; set; }

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
