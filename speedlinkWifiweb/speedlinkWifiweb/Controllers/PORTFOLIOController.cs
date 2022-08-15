using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Data;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.Models.mainpage;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace speedlinkWifiweb.Controllers
{
    [Authorize]
    public class PORTFOLIOController : Controller
    {

        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ApplicationDbContext db;

        public PORTFOLIOController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {

            db = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: mains
        public IActionResult index()
        {

          
            var result = db.PORTFOLIOs.OrderByDescending(x => x.id).ToList();
            return View(result);

        }

        // GET: mains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PORTFOLIOs = db.PORTFOLIOs
                .FirstOrDefault(m => m.id == id);
            if (PORTFOLIOs == null)
            {
                return NotFound();
            }

            return View(PORTFOLIOs);
        }

        // GET: mains/Create
        public ViewResult Create()
        {
 

            return View();
        }

        // POST: mains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        public async Task<IActionResult> Create(PORTFOLIO model)
        {

            if (ModelState.IsValid)
            {

                string unigueFileName = null;
                if (model.file != null && model.file.Count > 0)
                {
                    foreach (var photo in model.file)
                    {
                        string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "Image/main/PORTFOLIO");
                        unigueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsfolder, unigueFileName);

                        photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        model.Image = unigueFileName;



                        //for mult image 
                        //PORTFOLIO newPORTFOLIO = new PORTFOLIO
                        //{

                        //    Image = unigueFileName
                        //};
                        //db.Add(newPORTFOLIO);




                    }
                }
                db.Add(model);
                await db.SaveChangesAsync();
                TempData["SuccessMessage"] = "Upload Successfully";
                return RedirectToAction(nameof(Index));
            }

            return View(model);

        }

        //}
        // GET: mains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Create));
            }

            var pORTFOLIO = await db.PORTFOLIOs.FindAsync(id);
            if (pORTFOLIO == null)
            {
                return NotFound();
            }
            return View(pORTFOLIO);
        }

        // POST: mains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PORTFOLIO pORTFOLIO)
        {
            if (id != pORTFOLIO.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        string unigueFileName = null;
                        if (pORTFOLIO.file != null && pORTFOLIO.file.Count > 0)
                        {
                            foreach (var photo in pORTFOLIO.file)
                            {
                                string uploadsfolder = Path.Combine(_hostEnvironment.WebRootPath, "Image/main/PORTFOLIO");
                                unigueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                                string filePath = Path.Combine(uploadsfolder, unigueFileName);

                                photo.CopyTo(new FileStream(filePath, FileMode.Create));

                                pORTFOLIO.Image = unigueFileName;



                                //for mult image 
                                //PORTFOLIO newPORTFOLIO = new PORTFOLIO
                                //{

                                //    Image = unigueFileName
                                //};
                                //db.Add(newPORTFOLIO);




                            }
                        }
                    }
                    db.Add(pORTFOLIO);
                    db.Update(pORTFOLIO);
                    TempData["SuccessMessage"] = "Update Successfully";
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mainExists(pORTFOLIO.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pORTFOLIO);
        }

        // GET: mains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var p = await db.PORTFOLIOs
                .FirstOrDefaultAsync(m => m.id == id);
            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        //// POST: mains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pORTFOLIO = await db.PORTFOLIOs.FindAsync(id);
            db.PORTFOLIOs.Remove(pORTFOLIO);
            await db.SaveChangesAsync();
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool mainExists(int id)
        {
            return db.PORTFOLIOs.Any(e => e.id == id);
        }

    }
}
