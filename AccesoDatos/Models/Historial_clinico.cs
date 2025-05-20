using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Historial_clinico
{
    public int id_historial { get; set; }

    public int id_cita { get; set; }

    public int id_mascota { get; set; }

    public DateTime? fecha_hora { get; set; }

    public string? diagnostico { get; set; }

    public string? tratamiento { get; set; }

    public string? observaciones { get; set; }

    public int? id_veterinario { get; set; }

    public virtual Cita id_citaNavigation { get; set; } = null!;

    public virtual Mascota id_mascotaNavigation { get; set; } = null!;

    public virtual Usuario? id_veterinarioNavigation { get; set; }
}
