using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace speedlinkWifiweb.Models.mainpage
{
    public class PORTFOLIO
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; } = DateTime.Now;
        public string Image { get; set; }

        public string ImageType { get; set; }

        [NotMapped]
        public List<IFormFile> file { get; set; }

     

    }
}
