using Microsoft.EntityFrameworkCore;
using WebApiAuditoria.Models;

namespace WebApiAuditoria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
  
}
