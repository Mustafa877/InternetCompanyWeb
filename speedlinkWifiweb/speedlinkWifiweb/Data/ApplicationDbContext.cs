using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Models.mainpage;

namespace speedlinkWifiweb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    public DbSet<main> Mains { get; set; }
    public DbSet<About> abouts { get; set; }
    public DbSet<services> services { get; set; }
    public DbSet<PORTFOLIO> PORTFOLIOs { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<ContactUs> ContactUs { get; set; }

}
}