using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Mascota
{
    public int id_mascota { get; set; }

    public int id_cliente { get; set; }

    public string nombre { get; set; } = null!;

    public DateOnly? fecha_nacimiento { get; set; }

    public string? sexo { get; set; }

    public string especie { get; set; } = null!;

    public int? id_raza { get; set; }

    public string? color { get; set; }

    public decimal? peso { get; set; }

    public DateTime? fecha_registro { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Historial_clinico> Historial_clinico { get; set; } = new List<Historial_clinico>();

    public virtual Cliente id_clienteNavigation { get; set; } = null!;

    public virtual Raza? id_razaNavigation { get; set; }
}
