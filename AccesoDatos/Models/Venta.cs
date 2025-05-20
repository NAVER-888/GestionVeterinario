using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Venta
{
    public int id_venta { get; set; }

    public DateTime? fecha_hora_venta { get; set; }

    public int? id_cliente { get; set; }

    public int id_usuario { get; set; }

    public decimal total_venta { get; set; }

    public string? forma_pago { get; set; }

    public string? notas { get; set; }

    public virtual ICollection<Detalle_servicio_venta> Detalle_servicio_venta { get; set; } = new List<Detalle_servicio_venta>();

    public virtual ICollection<Detalle_venta> Detalle_venta { get; set; } = new List<Detalle_venta>();

    public virtual Cliente? id_clienteNavigation { get; set; }

    public virtual Usuario id_usuarioNavigation { get; set; } = null!;
}
