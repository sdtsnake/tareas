# tareas
proyecto de tareas en .net con sql server

Este proyecto tiene como objetivo realizar una api que nos permita <br>
realizar un manejo de tareas basico con C# usando entity framework <br>

Los principales conceptos se manejan en este proeycto es la creacion de <br>
la base de datos con entityfremework pasando por la creacion con anotaciones <br>
y despues usando fluent api incluyendo el versionador de la base de datos migrations <br>

<p> Nota : hay que recordar que para usar el migrations se debe instalar los complemnetos <br>
dotnet ef el cual pide instalar el nuget Microsoft.EntityFrameworkCore.Design, otro aspecto a tener <br>
es que para que funcione de manera correcta el migrations la base de datos debe ser creada con <br>
el comando dotnet ef migrations</p>

comandos :

dotnet ef migrations add InitialCreate -> Comando incial para crear la base de datos
dotnet ef migrations add NombreDelCambio -> de aqui en adelante se debe colocar por cada modificacion una etiqueta que haga referencia al cambio en la base datos.
dotnet ef database update -> actualiza la base de datos.
dotnet ef migrations add InitialData -> carga la informacion semilla de la base de datos.



