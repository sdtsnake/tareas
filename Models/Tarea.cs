using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectef.Models;

public class Tarea
{
    public Guid TareaId {get;set;}
    public Guid CategoriaId {get;set;}
    public String Titulo {get;set;}
    public String Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categoria {get;set;}
    public string Resumen {get;set;}
}

public enum Prioridad
{
    Baja,
    Medida,
    Alta
}