using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace speedlinkWifiweb.Models.mainpage
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string jop { get; set; }
        public string description { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }

        public string Image { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }

        public string faecbook { get; set; }
        public string instgerm { get; set; }
        public string linkin { get; set; }
        public string Twitter { get; set; }

    }
}
