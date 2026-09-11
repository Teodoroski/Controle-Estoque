using Microsoft.EntityFrameworkCore;
using Controle_Estoque.Models;

namespace Controle_Estoque.Context
{
    public class EstoqueContext : DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {
            
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
