using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(speedlinkWifiweb.Areas.Identity.IdentityHostingStartup))]
namespace speedlinkWifiweb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}