using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PracticaConMVC.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=equipos; User Id=sa; Password=hola123; Encrypt=False; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.IdEquipos).HasName("PK__equipos__E5821F7F2583136D");

            entity.ToTable("equipos");

            entity.Property(e => e.IdEquipos)
                .ValueGeneratedNever()
                .HasColumnName("id_equipos");
            entity.Property(e => e.AnioCompra).HasColumnName("anio_compra");
            entity.Property(e => e.Costo)
                .HasColumnType("numeric(18, 4)")
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.EstadoEquipoId).HasColumnName("estado_equipo_id");
            entity.Property(e => e.MarcaId).HasColumnName("marca_id");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoEquipoId).HasColumnName("tipo_equipo_id");
            entity.Property(e => e.VidaUtil).HasColumnName("vida_util");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarcas).HasName("PK__marcas__7918CF24365BAA63");

            entity.ToTable("marcas");

            entity.Property(e => e.IdMarcas).HasColumnName("id_marcas");
            entity.Property(e => e.Estados)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estados");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_marca");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
