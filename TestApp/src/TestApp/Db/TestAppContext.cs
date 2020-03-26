using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class TestAppContext : DbContext
    {
        public TestAppContext(DbContextOptions<TestAppContext> options)
            : base(options)
        { 
        }

        public DbSet<Film> Films { get; set; }

        public DbSet<Car> Cars { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");
    }
}
