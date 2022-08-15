using speedlinkWifiweb.Models.mainpage;
using System.Collections.Generic;

namespace speedlinkWifiweb.ViewModel
{
    public class ahomeModel
    {

        //public  blog  Blog { get; set; }
        public List<main> Main { get; set; }
        public List<About> about { get; set; }
        public List<PORTFOLIO> PORTFOLIO { get; set; }
        public List<services> services { get; set; }
        //public List<Category> ca { get; set; }
        public IEnumerable<Team> TEAM { get; set; }
        public ContactUs contactUs { get; set; }
    }
}
