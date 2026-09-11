using Controle_Estoque.Models;
using Microsoft.EntityFrameworkCore;

namespace Controle_Estoque.Context
{
    public class PerfilContext : DbContext
    {
        public PerfilContext(DbContextOptions<PerfilContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}