using Microsoft.EntityFrameworkCore;
using OfficeMgt.Models.Flg;

namespace OfficeMgt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<MissionType> MissionTypes { get; set; }

    }
}
