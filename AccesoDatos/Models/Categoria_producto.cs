using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Categoria_producto
{
    public int id_categoria { get; set; }

    public string nombre_categoria { get; set; } = null!;

    public string? descripcion { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
