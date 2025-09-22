using kreator_pomieszczen.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kreator_pomieszczen.Data
{
    public class AppDbContext : IdentityDbContext<Uzytkownicy>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
