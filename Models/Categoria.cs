using System.ComponentModel.DataAnnotations;

namespace proyectef.Models;

public class Categoria
{                
    public Guid CategoriaId {get;set;}
    public String Nombre {get;set;}
    public String Descripcion {get;set;}
    public virtual ICollection<Tarea> Tareas {get;set;}
}