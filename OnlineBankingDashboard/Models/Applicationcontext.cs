using Microsoft.EntityFrameworkCore;

namespace OnlineBankingDashboard.Models
{
    public class Applicationcontext:DbContext
    {
        public Applicationcontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> accounts { get; set; }

        public DbSet<User> users { get; set; }
    }
}
