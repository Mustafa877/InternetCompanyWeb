using Microsoft.AspNetCore.Http;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace speedlinkWifiweb.Models
{
    public class blog
    {
        public int ID { get; set; }
        public string mainName { get; set; }

        public string underneme { get; set; }
        public string Image { get; set; }

        [DataType(DataType.Date)]
        [JsonPropertyName("startDateTime")]
        public DateTime StartDate { get; set; }

        [NotMapped]
        public IFormFile file { get; set; }
    }
}