using Microsoft.EntityFrameworkCore;
using Practica2_Grupo4_PrograAvanzadaWeb.DAL.Entidades;

namespace Practica2_Grupo4_PrograAvanzadaWeb.DAL.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public virtual DbSet<Categoria> Categorias { get; set; }
    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categoria");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).IsRequired();
            entity.HasIndex(e => e.Nombre).IsUnique();
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("Producto");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Precio).HasColumnType("NUMERIC");
            entity.Property(e => e.FkCategoria).HasColumnName("FKCATEGORIA");

            entity.HasOne(p => p.FkCategoriaNavigation)
                  .WithMany(c => c.Productos)
                  .HasForeignKey(p => p.FkCategoria)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}