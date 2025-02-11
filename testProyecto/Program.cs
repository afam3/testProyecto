using Microsoft.EntityFrameworkCore;
using testProyecto.Datos;

var builder = WebApplication.CreateBuilder(args);

//configurar conexion con la bd
builder.Services.AddDbContext<ApplicationDbContext>(opciones => 
        opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //primero carga el controlador "Inicio" y despues carga el metodo "Index", por ahora no se utiliza el parametro ID
    pattern: "{controller=Inicio}/{action=Index}/{id?}");

app.Run();
