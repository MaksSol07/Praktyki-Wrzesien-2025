using kreator_pomieszczen.Models;
using Microsoft.EntityFrameworkCore;

namespace kreator_pomieszczen.Data
{
    public class PomieszczeniaDbContext : DbContext
    {
        public DbSet<Pomieszczenie> Pomieszczenia { get; set; }

        public PomieszczeniaDbContext(DbContextOptions<PomieszczeniaDbContext> options)
            : base(options)
        {
            
        }
    }
}
