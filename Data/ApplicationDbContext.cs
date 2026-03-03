using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Finance.Models;
using Finance.Controllers;

namespace Finance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        public DbSet<Finance.Models.Dergon> Dergon { get; set; } = default!;
        public DbSet<Finance.Models.Merret> Merret { get; set; } = default!;
        public DbSet<Finance.Models.Transaksione> Transaksione { get; set; } = default!;
    }
}
