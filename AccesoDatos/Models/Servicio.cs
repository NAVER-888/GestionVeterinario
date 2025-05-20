using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Servicio
{
    public int id_servicio { get; set; }

    public string nombre_servicio { get; set; } = null!;

    public string? descripcion { get; set; }

    public decimal precio { get; set; }

    public virtual ICollection<Detalle_cita> Detalle_cita { get; set; } = new List<Detalle_cita>();

    public virtual ICollection<Detalle_servicio_venta> Detalle_servicio_venta { get; set; } = new List<Detalle_servicio_venta>();

    public virtual ICollection<Servicio_precio_raza> Servicio_precio_raza { get; set; } = new List<Servicio_precio_raza>();
}
