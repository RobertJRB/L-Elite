using Microsoft.EntityFrameworkCore;
using ReservasMesas.Domain.Entities;

namespace ReservasMesas.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Area> Areas { get; set; }
    public DbSet<Mesa> Mesas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Observacion> Observaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(a => a.Tematica).HasMaxLength(200);
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Tipo).HasMaxLength(50);
            entity.HasOne(m => m.Area)
                  .WithMany(a => a.Mesas)
                  .HasForeignKey(m => m.AreaId);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Nombre).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Email).HasMaxLength(100);
            entity.Property(c => c.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.HasOne(r => r.Cliente)
                  .WithMany(c => c.Reservas)
                  .HasForeignKey(r => r.ClienteId);
            entity.HasOne(r => r.Mesa)
                  .WithMany()
                  .HasForeignKey(r => r.MesaId);
        });

        modelBuilder.Entity<Observacion>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Tipo).HasMaxLength(50);
            entity.Property(o => o.Descripcion).HasMaxLength(500);
            entity.HasOne(o => o.Reserva)
                  .WithMany(r => r.Observaciones)
                  .HasForeignKey(o => o.ReservaId);
        });

        base.OnModelCreating(modelBuilder);
    }
}