using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Detalle_venta
{
    public int id_detalle_venta { get; set; }

    public int id_venta { get; set; }

    public int id_producto { get; set; }

    public int cantidad { get; set; }

    public decimal precio_unitario { get; set; }

    public decimal? subtotal { get; set; }

    public decimal? igv { get; set; }

    public decimal? total { get; set; }

    public virtual Producto id_productoNavigation { get; set; } = null!;

    public virtual Venta id_ventaNavigation { get; set; } = null!;
}
