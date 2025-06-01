using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class ProductoCategoria
    {
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int CantidadEnStock { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
    }
}
