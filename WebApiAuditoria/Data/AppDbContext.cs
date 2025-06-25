using Microsoft.EntityFrameworkCore;

namespace WebApiAuditoria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

    }
  
}
