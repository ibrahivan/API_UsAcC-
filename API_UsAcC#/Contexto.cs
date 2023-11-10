using API_UsAcC_.Models;
using Microsoft.EntityFrameworkCore;

namespace API_UsAcC_
{
 
        // Se define el contexto de conexión a base de datos, que después
        // será instanciado como servicio para cada sesión https de usuario.
        public class Contexto : DbContext
        {
        // Se define un constructor que nos permita generar el contexto
        // como servicio desde el contenedor de servicios de la sesión https
        // de usuario.
   
        
            public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }
            public DbSet<Acceso> accesos { get; set; }
            public DbSet<Usuario> usuarios { get; set; }
        

    }
}
