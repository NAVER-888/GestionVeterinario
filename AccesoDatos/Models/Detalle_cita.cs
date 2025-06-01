using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Detalle_cita
{
    public int id_cita_servicio { get; set; }

    public int id_cita { get; set; }

    public int id_servicio { get; set; }

    public int cantidad { get; set; }

    public decimal precio_unitario { get; set; }

    public decimal? subtotal { get; set; }

    public decimal? igv { get; set; }

    public decimal? total { get; set; }

    public virtual Cita id_citaNavigation { get; set; } = null!;

    public virtual Servicio id_servicioNavigation { get; set; } = null!;
}
