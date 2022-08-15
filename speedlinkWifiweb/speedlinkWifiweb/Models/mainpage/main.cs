using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace speedlinkWifiweb.Models.mainpage
{
    public class main
    {
        public int id { get; set; }
        public string logo1 { get; set; }
        public string Title1 { get; set; }
        public string description1 { get; set; }
        public string mainImage1 { get; set; }

        [NotMapped]
        public IFormFile file_logo1 { get; set; }
        [NotMapped]
        public IFormFile file_mainImage1 { get; set; }



        ////////////// TESTIMONIALS
        /////pORTFOLIO
        //public string name { get; set; }
        //public string job { get; set; }
        //public string personImage { get; set; }
        //[NotMapped]
        //public IFormFile file_personImage { get; set; }



    }

}

