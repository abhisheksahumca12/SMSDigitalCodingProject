using Microsoft.EntityFrameworkCore;

namespace SMSDigitalCodingProject.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }

        public DbSet<CityDetail> CityDetails { get; set; }
    }
}
