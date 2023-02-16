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
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5be4dbfe-1be0-4e7e-9648-51e585602c40"), Nombre = "Actividades pendientes", Peso = 20});

        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("5be4dbfe-1be0-4e7e-9648-51e585602c20"), Nombre = "Actividades personales", Peso = 50});


        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");                                 
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(P=> P.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriasInit); 
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("5be4dbfe-1be0-4e7e-9648-51e585602c45"), CategoriaId = Guid.Parse("5be4dbfe-1be0-4e7e-9648-51e585602c40"), PrioridadTarea = Prioridad.Medida, Titulo ="Pagos de servicios publicos", FechaCreacion = DateTime.Now});
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("5be4dbfe-1be0-4e7e-9648-51e585602c25"), CategoriaId = Guid.Parse("5be4dbfe-1be0-4e7e-9648-51e585602c20"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar capitulo de the last of us en hbo", FechaCreacion = DateTime.Now });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasOne(t=> t.Categoria).WithMany(t=> t.Tareas).HasForeignKey(t=> t.CategoriaId);
            tarea.Property(t=> t.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(t => t.Descripcion).IsRequired(false); 
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.FechaCreacion);
            tarea.Ignore(t => t.Resumen);
            tarea.HasData(tareasInit); 

        });
      
    }
  

}