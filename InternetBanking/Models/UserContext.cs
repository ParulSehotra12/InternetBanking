using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<RegisterViewModel> registration { get; set; }
    }
}
