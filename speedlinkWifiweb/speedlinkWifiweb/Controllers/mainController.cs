using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using speedlinkWifiweb.Models;
using speedlinkWifiweb.Models.mainpage;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace speedlinkWifiweb.Controllers
{
    public class mainController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly Dbcount _context;

        public mainController(Dbcount context, IWebHostEnvironment hostEnvironment)
        {

            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: mains
        public async Task<IActionResult> index()
        {
            return View(await _context.Mains.ToListAsync());
        }

        // GET: mains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Mains
                .FirstOrDefaultAsync(m => m.id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // GET: mains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create(main main)
        {
            if (ModelState.IsValid)
            {
                uploadphotoaHomebgrond(main);
                uploadphotoaHomeLogo(main);
                _context.Add(main);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Upload Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(main);
        }

        // GET: mains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Create));
            }

            var main = await _context.Mains.FindAsync(id);
            if (main == null)
            {
                return NotFound();
            }
            return View(main);
        }

        // POST: mains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, main main)
        {
            if (id != main.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    uploadphotoaHomebgrond(main);
                    uploadphotoaHomeLogo(main);
                    _context.Update(main);
                    TempData["SuccessMessage"] = "Update Successfully";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mainExists(main.id))
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
            return View(main);
        }

        // GET: mains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Mains
                .FirstOrDefaultAsync(m => m.id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // POST: mains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var main = await _context.Mains.FindAsync(id);
            _context.Mains.Remove(main);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Delete Successfully";
            return RedirectToAction(nameof(Index));
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
        private bool mainExists(int id)
        {
            return _context.Mains.Any(e => e.id == id);
        }
    }
}
