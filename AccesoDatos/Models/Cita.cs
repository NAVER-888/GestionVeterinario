using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Cita
{
    public int id_cita { get; set; }

    public int id_mascota { get; set; }

    public DateTime fecha_hora { get; set; }

    public string motivo { get; set; } = null!;

    public int? id_veterinario { get; set; }

    public string? estado { get; set; }

    public string? notas { get; set; }

    public DateTime? fecha_creacion { get; set; }

    public virtual ICollection<Detalle_cita> Detalle_cita { get; set; } = new List<Detalle_cita>();

    public virtual ICollection<Historial_clinico> Historial_clinico { get; set; } = new List<Historial_clinico>();

    public virtual Mascota id_mascotaNavigation { get; set; } = null!;

    public virtual Usuario? id_veterinarioNavigation { get; set; }
}
