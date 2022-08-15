using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace speedlinkWifiweb.Models.mainpage
{
    public class About
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public string mainImage { get; set; }
        [NotMapped]
        public IFormFile file_mainImage { get; set; }
    }
}
