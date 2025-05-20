using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Detalle_servicio_venta
{
    public int id_detalle_servicio { get; set; }

    public int id_venta { get; set; }

    public int id_servicio { get; set; }

    public int cantidad { get; set; }

    public decimal precio_unitario { get; set; }

    public decimal? subtotal { get; set; }

    public decimal? igv { get; set; }

    public decimal? total { get; set; }

    public int? empleado_asignado { get; set; }

    public string? notas { get; set; }

    public virtual Usuario? empleado_asignadoNavigation { get; set; }

    public virtual Servicio id_servicioNavigation { get; set; } = null!;

    public virtual Venta id_ventaNavigation { get; set; } = null!;
}
