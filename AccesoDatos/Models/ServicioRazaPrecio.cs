using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class ServicioRazaPrecio
    {

        public string NombreServicio { get; set; }           // s.nombre_servicio
        public string DescripcionServicio { get; set; }      // s.descripcion AS descripcion_servicio
        public string NombreRaza { get; set; }               // r.nombre_raza
        public string DescripcionRaza { get; set; }          // r.descripcion AS descripcion_raza
        public string Especie { get; set; }                  // spr.especie
        public decimal PrecioPersonalizado { get; set; }     // spr.precio AS precio_personalizado

    }
}
