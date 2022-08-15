using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.Models.mainpage;
using System;
using System.IO;
using System.Linq;

namespace speedlinkWifiweb.Controllers
{
    [Authorize]
    public class admin_speed8090Controller : Controller
    {


        Dbcount db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public admin_speed8090Controller(Dbcount countrex, IWebHostEnvironment hostEnvironment)
        {
            db = countrex;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult profile()
        {
            return View();
        }
        public IActionResult Calendar()
        {
            return View();
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Dashboard()
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
        public IActionResult aHome()
        {


            return View();
        }

        [HttpPost]

        public IActionResult savecountion(blog blog)
        {

            uploadphoto(blog);
            db.blogs.Add(blog);
            db.SaveChanges();
            return RedirectToActionPermanent("blogpost");


        }
        [HttpPost]
        public IActionResult savecountionAhome(main Main)
        {
            uploadphotoaHomebgrond(Main);
            uploadphotoaHomeLogo(Main);
            db.Mains.Add(Main);
            db.SaveChanges();
            return RedirectToActionPermanent("aHome");


        }
        void uploadphoto(blog model)
        {
            if (model.file != null)
            {
                string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "Image/blog");

                string unigueFileName = Guid.NewGuid() + ".jpg";
                string filepath = Path.Combine(uploadsfolder, unigueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.file.CopyTo(filestream);

                }
                model.Image = unigueFileName;
            }
        }
        void uploadphotoaHomeLogo(main model)
        {
            if (model.file_logo1 != null)
            {
                string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "Image/main/logo");

                string unigueFileName = Guid.NewGuid() + ".jpg";
                string filepath = Path.Combine(uploadsfolder, unigueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.file_logo1.CopyTo(filestream);

                }
                model.logo1 = unigueFileName;
            }
        }
        void uploadphotoaHomebgrond(main model)
        {
            if (model.file_mainImage1 != null)
            {
                string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "Image/main/mainImage");

                string unigueFileName = Guid.NewGuid() + ".jpg";
                string filepath = Path.Combine(uploadsfolder, unigueFileName);
                using (var filestream = new FileStream(filepath, FileMode.Create))
                {
                    model.file_mainImage1.CopyTo(filestream);

                }
                model.mainImage1 = unigueFileName;
            }
        }
    }
}
