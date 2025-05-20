using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Producto
{
    public int id_producto { get; set; }

    public string nombre_producto { get; set; } = null!;

    public int id_categoria { get; set; }

    public string? descripcion { get; set; }

    public decimal precio_unitario { get; set; }

    public int cantidad_en_stock { get; set; }

    public DateTime? fecha_ultima_actualizacion { get; set; }

    public virtual ICollection<Detalle_venta> Detalle_venta { get; set; } = new List<Detalle_venta>();

    public virtual Categoria_producto id_categoriaNavigation { get; set; } = null!;
}
