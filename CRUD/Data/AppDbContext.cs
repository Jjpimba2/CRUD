using Microsoft.EntityFrameworkCore;
using CRUD.Model;
using CRUD.Model.CRUD.Model;

namespace CRUD.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ouvinte> Ouvintes { get; set; }
        public DbSet<Musico> Musicos { get; set; } // já pensando no login


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}