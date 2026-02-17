using Microsoft.EntityFrameworkCore;
using CRUD.Model;

namespace CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}