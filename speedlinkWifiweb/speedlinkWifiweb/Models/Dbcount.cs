using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Models.mainpage;

namespace speedlinkWifiweb.Models
{
    public class Dbcount : DbContext
    {
        public Dbcount()
        {
        }

        public Dbcount(DbContextOptions<Dbcount> options)
            : base(options)
        {
        }

        //public DbSet<blog> blogs { get; set; }
        public DbSet<main> Mains { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<services> services { get; set; }
        public DbSet<PORTFOLIO> PORTFOLIOs { get; set; }
        //public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }
        //public virtual DbSet<OurClients> OurClients { get; set; }



    }
}
