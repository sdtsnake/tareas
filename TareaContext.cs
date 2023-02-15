using Microsoft.EntityFrameworkCore;
using proyectef.Models;
using System.Runtime;

namespace proyectef;


public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");                                 
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(P=> P.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasOne(t=> t.Categoria).WithMany(t=> t.Tareas).HasForeignKey(t=> t.CategoriaId);
            tarea.Property(t=> t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion); 
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);

        });
      
    }
  

}