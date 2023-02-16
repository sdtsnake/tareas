using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectef;
using proyectef.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareaDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas.Include(t=> t.Categoria));
        
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddRangeAsync(tarea);   
    await dbContext.SaveChangesAsync(); 
   
    return Results.Ok();

});


app.Run();
