using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Usuario
{
    public int id_usuario { get; set; }

    public string nombre { get; set; } = null!;

    public string apellido { get; set; } = null!;

    public string email { get; set; } = null!;

    public string contrasena { get; set; } = null!;

    public string rol { get; set; } = null!;

    public string? estado { get; set; }

    public DateTime? fecha_creacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Detalle_servicio_venta> Detalle_servicio_venta { get; set; } = new List<Detalle_servicio_venta>();

    public virtual ICollection<Historial_clinico> Historial_clinico { get; set; } = new List<Historial_clinico>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
