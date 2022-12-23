using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Models;

namespace MvcWorkspace.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { }

        //DbSets Area
        public DbSet<Personel> personels { get; set; }
        public DbSet<Bolum> bolums { get; set; }
    }
}
