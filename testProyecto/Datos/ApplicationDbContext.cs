using Microsoft.EntityFrameworkCore;
using testProyecto.Models;

namespace testProyecto.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Aqui se van a agregar los modelos de datos
        public DbSet<Correo>Correo { get; set; }
    }
}
