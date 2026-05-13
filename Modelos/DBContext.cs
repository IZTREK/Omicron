using Microsoft.EntityFrameworkCore;

namespace Usuarios.Modelos
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        // Define un DbSet para la entidad Mob, lo que permite realizar operaciones CRUD sobre la tabla correspondiente en la base de datos
        public DbSet<Producto> Productos { get; set; }
    }
}