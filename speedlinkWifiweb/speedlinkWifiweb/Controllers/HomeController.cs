using Microsoft.AspNetCore.Mvc;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.ViewModel;
using System.Diagnostics;
using System.Linq;

namespace speedlinkWifiweb.Controllers
{

    public class HomeController : Controller
    {



        Dbcount db;
        public HomeController(Dbcount countrex)
        {
            db = countrex;

        }


        public IActionResult Index()
        {
            var tables = new ahomeModel()
            {

                Main = db.Mains.ToList(),
                services = db.services.ToList(),
                PORTFOLIO = db.PORTFOLIOs.OrderByDescending(x => x.id).ToList(),
                about = db.abouts.OrderByDescending(x => x.id).ToList(),
                TEAM = db.Teams.OrderByDescending(x => x.id).ToList(),


            };

            return View(tables);
        }

        public IActionResult blog()
        {
            var result = db.blogs.OrderByDescending(x => x.ID).ToList();
            return View(result);
        }
        public IActionResult admin()
        {

            return View();
        }
        public IActionResult blogdashboard()
        {

            return View();
        }
        public IActionResult blogpost()
        {

            return View();
        }
        public IActionResult signin()
        {

            return View();
        }
        public IActionResult bloglist()
        {
            var result = db.blogs.OrderByDescending(x => x.ID).ToList();
            return View(result);
        }
        public IActionResult signup()
        {

            return View();
        }

        [HttpPost]

        public IActionResult savecountion(blog model)
        {

            db.blogs.Add(model);
            db.SaveChanges();
            return RedirectToActionPermanent("blogpost");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
