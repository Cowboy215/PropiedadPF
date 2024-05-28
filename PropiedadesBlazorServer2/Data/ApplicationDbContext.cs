using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropiedadesBlazorServer2.Modelos;

namespace PropiedadesBlazorServer2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //Agregamos Los modelos.

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Propiedad> Propiedad { get; set; }
        public DbSet<ImagenPropiedad> ImagenPropiedad { get; set; }

    }
}
