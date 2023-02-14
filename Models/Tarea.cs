using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectef.Models;

public class Tarea
{
    [Key]
    public Guid TareaId {get;set;}
    [ForeignKey("Fk_Categoria_Id")]
    public Guid CategoriaId {get;set;}
    [Required]
    [MaxLength(200)]
    public String Titulo {get;set;}
    public String Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categoria {get;set;}
    [NotMapped]
    public string Resumen {get;set;}
}

public enum Prioridad
{
    Baja,
    Medida,
    Alta
}