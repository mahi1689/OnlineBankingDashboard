using Microsoft.EntityFrameworkCore;


namespace OnlineBankingDashboard.Models
{
    public class ChangerUserIdPwdContext: DbContext
    {
        
        public ChangerUserIdPwdContext(DbContextOptions<ChangerUserIdPwdContext> options):base(options)
        {

        }


        public DbSet<ChangerUserIdPwdContexts> ChangerUserIdPwdContexts { get; set; }

       
    }
}
