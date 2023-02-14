using System.ComponentModel.DataAnnotations;

namespace proyectef.Models;

public class Categoria
{
    [Key]
    public Guid CategoriaId {get;set;}
    [Required]
    [MaxLength(150)]
    public String Nombre {get;set;}
    public String Descripcion {get;set;}
    public virtual ICollection<Tarea> Tareas {get;set;}
}