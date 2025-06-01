using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class BD_GESTION_VETERINARIAContext : DbContext
{
    public BD_GESTION_VETERINARIAContext()
    {
    }

    public BD_GESTION_VETERINARIAContext(DbContextOptions<BD_GESTION_VETERINARIAContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria_producto> Categoria_producto { get; set; }

    public virtual DbSet<Cita> Cita { get; set; }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<Detalle_cita> Detalle_cita { get; set; }

    public virtual DbSet<Detalle_servicio_venta> Detalle_servicio_venta { get; set; }

    public virtual DbSet<Detalle_venta> Detalle_venta { get; set; }

    public virtual DbSet<Historial_clinico> Historial_clinico { get; set; }

    public virtual DbSet<Mascota> Mascota { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Raza> Raza { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<Servicio_precio_raza> Servicio_precio_raza { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UQKKCKS;Database=BD_GESTION_VETERINARIA;Trust Server Certificate=true;User Id=Erick;Password=admin;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria_producto>(entity =>
        {
            entity.HasKey(e => e.id_categoria).HasName("PK__Categori__CD54BC5A2678A498");

            entity.HasIndex(e => e.nombre_categoria, "UQ__Categori__4EBF62595B144155").IsUnique();

            entity.Property(e => e.descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.nombre_categoria)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.id_cita).HasName("PK__Cita__6AEC3C09E95CCA10");

            entity.Property(e => e.estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.fecha_creacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.fecha_hora).HasColumnType("datetime");
            entity.Property(e => e.motivo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.notas).IsUnicode(false);

            entity.HasOne(d => d.id_mascotaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.id_mascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cita__id_mascota__35BCFE0A");

            entity.HasOne(d => d.id_veterinarioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.id_veterinario)
                .HasConstraintName("FK__Cita__id_veterin__36B12243");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.id_cliente).HasName("PK__Cliente__677F38F5EB3C5D5F");

            entity.Property(e => e.apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.direccion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.fecha_registro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Detalle_cita>(entity =>
        {
            entity.HasKey(e => e.id_cita_servicio).HasName("PK__Detalle___9F00D22970A2DAFA");

            entity.Property(e => e.cantidad).HasDefaultValue(1);
            entity.Property(e => e.igv)
                .HasComputedColumnSql("(round(([cantidad]*[precio_unitario])*(0.18),(2)))", true)
                .HasColumnType("numeric(24, 4)");
            entity.Property(e => e.precio_unitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.subtotal)
                .HasComputedColumnSql("([cantidad]*[precio_unitario])", true)
                .HasColumnType("decimal(21, 2)");
            entity.Property(e => e.total)
                .HasComputedColumnSql("(round(([cantidad]*[precio_unitario])*(1.18),(2)))", true)
                .HasColumnType("numeric(25, 4)");

            entity.HasOne(d => d.id_citaNavigation).WithMany(p => p.Detalle_cita)
                .HasForeignKey(d => d.id_cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_c__id_ci__46E78A0C");

            entity.HasOne(d => d.id_servicioNavigation).WithMany(p => p.Detalle_cita)
                .HasForeignKey(d => d.id_servicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_c__id_se__47DBAE45");
        });

        modelBuilder.Entity<Detalle_servicio_venta>(entity =>
        {
            entity.HasKey(e => e.id_detalle_servicio).HasName("PK__Detalle___5B2B9FD9095C82A1");

            entity.Property(e => e.cantidad).HasDefaultValue(1);
            entity.Property(e => e.igv)
                .HasComputedColumnSql("(round(([cantidad]*[precio_unitario])*(0.18),(2)))", true)
                .HasColumnType("numeric(24, 4)");
            entity.Property(e => e.notas).IsUnicode(false);
            entity.Property(e => e.precio_unitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.subtotal)
                .HasComputedColumnSql("([cantidad]*[precio_unitario])", true)
                .HasColumnType("decimal(21, 2)");
            entity.Property(e => e.total)
                .HasComputedColumnSql("(round(([cantidad]*[precio_unitario])*(1.18),(2)))", true)
                .HasColumnType("numeric(25, 4)");

            entity.HasOne(d => d.empleado_asignadoNavigation).WithMany(p => p.Detalle_servicio_venta)
                .HasForeignKey(d => d.empleado_asignado)
                .HasConstraintName("FK__Detalle_s__emple__59FA5E80");

            entity.HasOne(d => d.id_servicioNavigation).WithMany(p => p.Detalle_servicio_venta)
                .HasForeignKey(d => d.id_servicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_s__id_se__59063A47");

            entity.HasOne(d => d.id_ventaNavigation).WithMany(p => p.Detalle_servicio_venta)
                .HasForeignKey(d => d.id_venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_s__id_ve__5812160E");
        });

        modelBuilder.Entity<Detalle_venta>(entity =>
        {
            entity.HasKey(e => e.id_detalle_venta).HasName("PK__Detalle___5B265D474793C15A");

            entity.Property(e => e.igv)
                .HasComputedColumnSql("(round(([cantidad]*[precio_unitario])*(0.18),(2)))", true)
                .HasColumnType("numeric(24, 4)");
            entity.Property(e => e.precio_unitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.subtotal)
                .HasComputedColumnSql("([cantidad]*[precio_unitario])", true)
                .HasColumnType("decimal(21, 2)");
            entity.Property(e => e.total)
                .HasComputedColumnSql("(round(([cantidad]*[precio_unitario])*(1.18),(2)))", true)
                .HasColumnType("numeric(25, 4)");

            entity.HasOne(d => d.id_productoNavigation).WithMany(p => p.Detalle_venta)
                .HasForeignKey(d => d.id_producto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_v__id_pr__5DCAEF64");

            entity.HasOne(d => d.id_ventaNavigation).WithMany(p => p.Detalle_venta)
                .HasForeignKey(d => d.id_venta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_v__id_ve__5CD6CB2B");
        });

        modelBuilder.Entity<Historial_clinico>(entity =>
        {
            entity.HasKey(e => e.id_historial).HasName("PK__Historia__76E6C502B0202388");

            entity.Property(e => e.diagnostico).IsUnicode(false);
            entity.Property(e => e.fecha_hora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.observaciones).IsUnicode(false);
            entity.Property(e => e.tratamiento).IsUnicode(false);

            entity.HasOne(d => d.id_citaNavigation).WithMany(p => p.Historial_clinico)
                .HasForeignKey(d => d.id_cita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__id_ci__3A81B327");

            entity.HasOne(d => d.id_mascotaNavigation).WithMany(p => p.Historial_clinico)
                .HasForeignKey(d => d.id_mascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__id_ma__3B75D760");

            entity.HasOne(d => d.id_veterinarioNavigation).WithMany(p => p.Historial_clinico)
                .HasForeignKey(d => d.id_veterinario)
                .HasConstraintName("FK__Historial__id_ve__3C69FB99");
        });

        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.HasKey(e => e.id_mascota).HasName("PK__Mascota__6F0373525A5D7BAB");

            entity.Property(e => e.color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.especie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.fecha_registro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.id_clienteNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.id_cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Mascota__id_clie__300424B4");

            entity.HasOne(d => d.id_razaNavigation).WithMany(p => p.Mascota)
                .HasForeignKey(d => d.id_raza)
                .HasConstraintName("FK__Mascota__id_raza__30F848ED");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.id_producto).HasName("PK__Producto__FF341C0DF1813CD0");

            entity.Property(e => e.descripcion).IsUnicode(false);
            entity.Property(e => e.fecha_ultima_actualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nombre_producto)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.precio_unitario).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_categoriaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.id_categoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Producto__id_cat__4F7CD00D");
        });

        modelBuilder.Entity<Raza>(entity =>
        {
            entity.HasKey(e => e.id_raza).HasName("PK__Raza__084F250ACEB44398");

            entity.HasIndex(e => e.nombre_raza, "UQ__Raza__BD71773CCBD5070D").IsUnique();

            entity.Property(e => e.descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.nombre_raza)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.id_servicio).HasName("PK__Servicio__6FD07FDCDA079DE3");

            entity.Property(e => e.descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.nombre_servicio)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.precio).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Servicio_precio_raza>(entity =>
        {
            entity.HasKey(e => e.id_servicio_precio).HasName("PK__Servicio__7F6E8AD0919A9510");

            entity.HasIndex(e => new { e.id_servicio, e.id_raza, e.especie }, "UQ_Servicio_raza_especie").IsUnique();

            entity.Property(e => e.especie)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_razaNavigation).WithMany(p => p.Servicio_precio_raza)
                .HasForeignKey(d => d.id_raza)
                .HasConstraintName("FK__Servicio___id_ra__4316F928");

            entity.HasOne(d => d.id_servicioNavigation).WithMany(p => p.Servicio_precio_raza)
                .HasForeignKey(d => d.id_servicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Servicio___id_se__4222D4EF");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.id_usuario).HasName("PK__Usuario__4E3E04AD5E9F12B8");

            entity.HasIndex(e => e.email, "UQ__Usuario__AB6E616417015C49").IsUnique();

            entity.Property(e => e.apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.contrasena)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Activo");
            entity.Property(e => e.fecha_creacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.id_venta).HasName("PK__Venta__459533BF56F359F1");

            entity.Property(e => e.fecha_hora_venta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.forma_pago)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.notas).IsUnicode(false);
            entity.Property(e => e.total_venta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.id_clienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.id_cliente)
                .HasConstraintName("FK__Venta__id_client__534D60F1");

            entity.HasOne(d => d.id_usuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.id_usuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Venta__id_usuari__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
