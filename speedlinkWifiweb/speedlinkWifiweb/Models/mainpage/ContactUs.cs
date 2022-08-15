using System;

namespace speedlinkWifiweb.Models.mainpage
{
    public class ContactUs
    {
        public int Id { get; set; }

        public DateTime date { get; set; } = DateTime.Now;
        public string name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
