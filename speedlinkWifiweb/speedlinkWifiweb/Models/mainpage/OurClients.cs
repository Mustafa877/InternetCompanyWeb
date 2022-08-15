using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace speedlinkWifiweb.Models.mainpage
{
    public class OurClients
    {
        public int id { get; set; }

        public string image { get; set; }

        [NotMapped]

        public IFormFile file { get; set; }
    }
}
